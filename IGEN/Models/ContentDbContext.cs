using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IGEN.Models
{
    public class ContentDbContext : DbContext
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<HomeEdit> HomeEdit { get; set; }
        public DbSet<Gamedeveloper> Gamedeveloper { get; set; }
    }
}