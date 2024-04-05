using Microsoft.EntityFrameworkCore;
using product.Models;

namespace MyWebApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Authors> Authors { get; set; }

            public DbSet<Book> Book { get; set; }

                public DbSet<Report> Report { get; set; }
            

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("metro");
             modelBuilder.Ignore<Product>();
            modelBuilder.Ignore<Book>();
            modelBuilder.Ignore<Authors>();
            modelBuilder.Ignore<User>();
             
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        }

        
    }
}