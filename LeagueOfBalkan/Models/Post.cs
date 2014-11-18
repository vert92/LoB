using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public int ThreadID { get; set; }
        public int AuthorID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
    }
}