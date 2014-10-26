using LeagueOfBalkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<News> CarouselNews { get; set; }
        public IEnumerable<News> MainNews { get; set; }
        public IEnumerable<News> MiniNews { get; set; }
    }
}