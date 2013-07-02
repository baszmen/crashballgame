using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CrashBall.Model
{
    public class Ball
    {
        [JsonProperty("Left")]
        public int Left { get; set; }
        [JsonProperty("Top")]
        public int Top { get; set; }
        [JsonProperty("Speed")]
        public int Speed { get; set; }
        [JsonProperty("Vector")]
        public Vector Vector { get; set; }
    }

    public class Vector
    {
        [JsonProperty("StartTop")]
        public int StartTop { get; set; }
        [JsonProperty("StartLeft")]
        public int StartLeft { get; set; }
        [JsonProperty("EndTop")]
        public int EndTop { get; set; }
        [JsonProperty("EndLeft")]
        public int EndLeft { get; set; }
    }
}