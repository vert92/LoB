using LeagueOfBalkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.ViewModels
{
    public class StreamPageViewModel
    {
        public TwitchData Stream { get; set; }
        public IEnumerable<TwitchData> StreamData { get; set; }
    }
}