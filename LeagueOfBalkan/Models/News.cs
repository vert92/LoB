﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfBalkan.Models
{
    public class News
    {
        public News()
        {
            this.Date = DateTime.Now;
        }

        public News(DateTime date)
        {
            this.Date = date;
        }

        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Text { get; set; }
        [DisplayName("Image Upload")]
        [NotMapped]
        public HttpPostedFileBase Image { get; set; }
        public string ImagePath { get; set; }
        public string ThumbPath { get; set; }
        
        public DateTime Date { get; set; }
    }

}