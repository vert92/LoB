using LeagueOfBalkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.ViewModels
{
    public class NewsDetailsViewModel
    {
        public News NewsDetail { get; set; }
        public IEnumerable<News> RecentNews { get; set; }
        public IEnumerable<TwitchData> StreamData { get; set; }
    }
}