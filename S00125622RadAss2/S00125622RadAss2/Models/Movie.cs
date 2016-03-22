using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00125622RadAss2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}