using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00125622RadAss2.Models
{
    public class Director
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}