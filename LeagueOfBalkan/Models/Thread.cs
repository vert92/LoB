using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueOfBalkan.Models
{
    public class Thread
    {
        public Thread()
        {
            DateCreated = DateTime.Now;
            DateEdited = DateTime.Now;
        }

        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ViewCount { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateEdited { get; set; }
        public int DiscussionID { get; set; }
        public int AuthorID { get; set; }
    }
}