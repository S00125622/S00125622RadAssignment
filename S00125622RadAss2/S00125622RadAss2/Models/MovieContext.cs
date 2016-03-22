using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00125622RadAss2.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=MovieContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<S00125622RadAss2.Models.Director> Directors { get; set; }
        public System.Data.Entity.DbSet<S00125622RadAss2.Models.Director> Movies { get; set; }
    }
}