using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.Models
{
    public class LoBDb : DbContext
    {
        public LoBDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<TwitchData> TwitchData { get; set; }
    }

}