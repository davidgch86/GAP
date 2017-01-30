using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SuperZapatosAPI.Data
{
    public class SuperZapatosContext : DbContext
    {
        // Tables Relates
        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}