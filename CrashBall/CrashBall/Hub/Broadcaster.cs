using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CrashBall.Model;
using Microsoft.AspNet.SignalR;

namespace CrashBall.Hub
{
    public class Broadcaster
    {
        public Dictionary<int, Group> Groups = new Dictionary<int, Group>();
        public Dictionary<string, Player> Players = new Dictionary<string, Player>();
        public Dictionary<Player, int> PlayerToGroup = new Dictionary<Player, int>();
        public int GroupId = 0;

        private readonly static Lazy<Broadcaster> _instance =
            new Lazy<Broadcaster>(() => new Broadcaster());
        // We're going to broadcast to all clients a maximum of 25 times per second
        private readonly TimeSpan BroadcastInterval =
            TimeSpan.FromMilliseconds(40);
        private readonly IHubContext _hubContext;
        private Timer _broadcastLoop;
        private bool _modelUpdated;

        public Broadcaster()
        {
            // Save our hub context so we can easily use it 
            // to send to its connected clients
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<CrashBallHub.CrashBallHub>();

            _modelUpdated = false;

            // Start the broadcast loop
            _broadcastLoop = new Timer(
                BroadcastShape,
                null,
                BroadcastInterval,
                BroadcastInterval);
        }

        public void BroadcastShape(object state)
        {
            foreach (var group in Groups.Values)
            {
                group.Players.ForEach(player => _hubContext.Clients.Client(player.Id).updateScreen(new Message
                    {
                        Players = @group.Players
                    }));
            }
        }

        public static Broadcaster Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}