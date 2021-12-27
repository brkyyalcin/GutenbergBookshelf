using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GutenbergBookshelf.Models
{
    public class GutenbergDbContext : DbContext
    {

        public GutenbergDbContext(DbContextOptions<GutenbergDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(w => w.Id)
                .IsUnique();

            builder.Entity<User>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Book>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Book>()
               .HasIndex(w => w.Id)
               .IsUnique();

        }


    }
}
