using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.Models
{
    public class TwitchData
    {
        public int ID { get; set; }
        public int viewers { get; set; }
        public string medium { get; set; }
        public string display_name { get; set; }
        public string status { get; set; }
        public string url { get; set; }
    }
}