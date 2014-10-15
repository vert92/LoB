using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.Models
{
    public class News
    {
        public News()
        {
            this.Date = DateTime.Now;
        }

        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }
        
        public DateTime Date { get; set; }
    }

    public class NewsDBContext : DbContext
    {
        public NewsDBContext() : base("DefaultConnection") { }

        public DbSet<News> News { get; set; }
    }
}