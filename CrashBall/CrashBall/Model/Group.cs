using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrashBall.Model
{
    public class Group
    {
        public List<Player> Players { get; set; }
        public bool Updated { get; set; }
 
        public Group()
        {
            Players = new List<Player>();
            Updated = true;
        }
    }
}