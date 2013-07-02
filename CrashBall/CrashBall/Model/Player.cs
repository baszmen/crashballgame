using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CrashBall.Model
{
    public class Player
    {
        public string Id { get; set; }
        public int BoardPosition { get; set; }

        [JsonProperty("Position")]
        public int PlatformPosition { get; set; }
        [JsonProperty("Lifes")]
        public int Lifes { get; set; }
    }
}