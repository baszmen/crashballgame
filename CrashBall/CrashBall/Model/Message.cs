using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CrashBall.Model
{
    public class Message
    {
        [JsonProperty("Players")]
        public List<Player> Players { get; set; }
        [JsonProperty("Balls")]
        public List<Ball> Balls { get; set; }
    }
}