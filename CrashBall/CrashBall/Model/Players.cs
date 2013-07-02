using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CrashBall.Model
{
    public class Players
    {
        [JsonProperty("Players")]
        public List<Player> PlayersList { get; set; } 
    }
}