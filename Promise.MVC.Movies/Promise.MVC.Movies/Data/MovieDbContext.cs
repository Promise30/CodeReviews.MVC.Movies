using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Promise.MVC.Movies.Models;
using Microsoft.AspNetCore.Identity;

namespace Promise.MVC.Movies.Data
{
    public class MovieDbContext : IdentityDbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<LogEntry> LogEntries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Movie>().Property(m => m.Id).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Title).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Director).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Price).HasPrecision(10, 2).IsRequired();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2010, 7, 16), Title = "Inception", Id = 1 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2012, 7, 20), Title = "The Dark Knight Rises", Id = 2 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2014, 11, 7), Title = "Interstellar", Id = 3 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2017, 7, 21), Title = "Dunkirk", Id = 4 },
                new Movie { Director = "Christopher Nolan", Genre = "Action", Price = 10.99m, ReleaseDate = new DateTime(2020, 7, 17), Title = "Tenet", Id = 5 }
            );

            // Seed users only
            var hasher = new PasswordHasher<IdentityUser>();
            
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    UserName = "johndoe@gmail.com",
                    NormalizedUserName = "JOHNDOE@GMAIL.COM",
                    Email = "johndoe@gmail.com",
                    NormalizedEmail = "JOHNDOE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = string.Empty,
                    ConcurrencyStamp = "c8554266-b401-4513-9e3d-9dcf5c6bf8f8"
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    UserName = "janedoe@gmail.com",
                    NormalizedUserName = "JANEDOE@GMAIL.COM",
                    Email = "janedoe@gmail.com",
                    NormalizedEmail = "JANEDOE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password456!"),
                    SecurityStamp = string.Empty,
                    ConcurrencyStamp = "c8554266-b401-4513-9e3d-9dcf5c6bf8f9"
                }
            );
        }
    }
}
