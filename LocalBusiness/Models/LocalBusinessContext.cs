using Microsoft.EntityFrameworkCore;

namespace LocalBusiness.Models
{
    public class LocalBusinessContext : DbContext
    {
        public LocalBusinessContext(DbContextOptions<LocalBusinessContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Business>()
                .HasData(
                    new Business { BusinessId = 1, Name = "United States",City = "Chicago", Rating = 5, Review = "I saw the giant bean!" },
                    new Business { BusinessId = 2, Name = "England",City = "London", Rating = 5, Review = "Foggy, but that was ok" },
                    new Business { BusinessId = 3, Name = "United States",City = "Chicago", Rating = 3, Review = "I thought it would be windier" },
                    new Business { BusinessId = 4, Name = "England",City = "London", Rating = 1, Review = "Couldn't even go to the beach" },
                    new Business { BusinessId = 5, Name = "France",City = "Paris", Rating = 2, Review = "Everyone was smoking" },
                    new Business { BusinessId = 6, Name = "Italy",City = "Rome", Rating = 5, Review = "Pretty!" }
                    );
        }

        public DbSet<Business> Businesses { get; set; }
    }
}