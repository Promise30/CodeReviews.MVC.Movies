using Microsoft.EntityFrameworkCore;
using Promise.MVC.Movies.Models;

namespace Promise.MVC.Movies.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies => Set<Movie>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Movie>().Property(m => m.Id).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Title).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Director).IsRequired();
            modelBuilder.Entity<Movie>().Property(m=> m.Price).HasPrecision(10,2).IsRequired();
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Movie>().HasData(
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2010, 7, 16), Title = "Inception", Id = 1 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2012, 7, 20), Title = "The Dark Knight Rises", Id = 2 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2014, 11, 7), Title = "Interstellar", Id = 3 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2017, 7, 21), Title = "Dunkirk", Id = 4 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2020, 7, 17), Title = "Tenet", Id = 5 }

                );
        }
    }
}
