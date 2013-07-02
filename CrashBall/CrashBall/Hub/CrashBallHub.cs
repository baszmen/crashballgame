using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CrashBall.Hub;
using CrashBall.Model;
using Microsoft.AspNet.SignalR;

namespace CrashBallHub
{
    public class CrashBallHub : Hub
    {
        private Broadcaster _broadcaster;

        public CrashBallHub()
            : this(Broadcaster.Instance)
        {
        }

        public CrashBallHub(Broadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        /// <summary>
        /// Pierwsze połączenie z serwerem
        /// </summary>
        public void Connect()
        {
            Clients.Caller.updateScreen(_broadcaster.Players[Context.ConnectionId].PlatformPosition);
        }

        /// <summary>
        /// Ruszanie platformą
        /// </summary>
        /// <param name="offset">Przesinięcie w osi OX lub OY </param>
        public void MovePlatform(int offset)
        {
            var player = _broadcaster.Players[Context.ConnectionId];
            player.PlatformPosition += offset;
            player.PlatformPosition = Math.Min(484, player.PlatformPosition);
            player.PlatformPosition = Math.Max(90, player.PlatformPosition);
            _broadcaster.Groups[_broadcaster.PlayerToGroup[player]].Updated = true;

            Clients.Caller.updateScreen(new Message
                {
                    Players = _broadcaster.Groups[_broadcaster.PlayerToGroup[player]].Players
                });
        }

        /// <summary>
        /// Usuwanie gracza z grupy, listy graczy itd.
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnected()
        {
            #region Clear references

            var player = _broadcaster.Players[Context.ConnectionId];
            _broadcaster.Groups[_broadcaster.PlayerToGroup[player]].Players.Remove(player);
            _broadcaster.PlayerToGroup.Remove(player);
            _broadcaster.Players.Remove(Context.ConnectionId);
            player = null;

            #endregion

            return base.OnDisconnected();
        }

        /// <summary>
        /// Tworzenie nowego gracza, ustawianie jego parametrów, wysuzkiwanie grupy
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            #region New player initialization
            var newPlayer = new Player
            {
                Id = Context.ConnectionId,
                Lifes = 3,
                PlatformPosition = 257
            };
            #endregion

            _broadcaster.Players[Context.ConnectionId] = newPlayer;

            // Tworzenie nowej grupy, jeśli przypadek skrajny
            if (_broadcaster.GroupId == 0 && !_broadcaster.Groups.ContainsKey(_broadcaster.GroupId))
                _broadcaster.Groups[_broadcaster.GroupId] = new Group();

            #region Search group for player

            for (var i = 0; i <= _broadcaster.GroupId; i++)
            {
                if (_broadcaster.Groups.ContainsKey(i) && _broadcaster.Groups[_broadcaster.GroupId].Players.Count < 4)
                {
                    newPlayer.BoardPosition = _broadcaster.Groups[_broadcaster.GroupId].Players.Count;
                    _broadcaster.Groups[_broadcaster.GroupId].Players.Add(newPlayer);
                    _broadcaster.PlayerToGroup[newPlayer] = _broadcaster.GroupId;
                    Groups.Add(Context.ConnectionId, _broadcaster.GroupId.ToString(CultureInfo.InvariantCulture));

                    Clients.Caller.updateScreen(newPlayer.PlatformPosition);
                    return base.OnConnected();
                }
            }
            #endregion

            //Jeśli nie ma miejsca w żadnej z grupy, tworzymy nową grupę dla gracza
            #region New group for player
            _broadcaster.GroupId++;
            _broadcaster.Groups[_broadcaster.GroupId] = new Group();
            newPlayer.BoardPosition = 0;
            _broadcaster.Groups[_broadcaster.GroupId].Players.Add(newPlayer);
            _broadcaster.PlayerToGroup[newPlayer] = _broadcaster.GroupId;
            Groups.Add(Context.ConnectionId, _broadcaster.GroupId.ToString(CultureInfo.InvariantCulture));
            #endregion

            return base.OnConnected();
        }
    }
}