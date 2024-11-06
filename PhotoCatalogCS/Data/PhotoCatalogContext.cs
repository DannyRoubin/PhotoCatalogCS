using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoCatalogCS.Models;

namespace PhotoCatalogCS.Data
{
    public class PhotoCatalogContext : DbContext
    {
        public PhotoCatalogContext(DbContextOptions<PhotoCatalogContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Photoshoot> Photoshoots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Here, you can define any specific configurations for the models, like relationships or constraints.
        }
    }
}




