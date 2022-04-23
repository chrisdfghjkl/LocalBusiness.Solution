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
                    new Business { BusinessId = 1, Name = "Cubo", Category = "Food & Drink", Description = "Cuban joint serves up homestyle fare plus cocktails in casual, vibrant surrounds with a patio.", Phone = "(971) 544-7801", Address = "3106 SE Hawthorne Blvd", City = "Portland", State = "OR", Zip = "97214"},
                    new Business { BusinessId = 2, Name = "Gado Gado", Category = "Food & Drink", Description = "Asian fusion dishes in quaint surrounds", Phone = "(503) 206-8778", Address = "1801 NE Cesar E Chavez Blvd", City = "Portland", State = "OR", Zip = "97212"},
                    new Business { BusinessId = 3, Name = "Powell's City of Books", Category = "Retail", Description = "Iconic bookstore occupying a city block", Phone = "(971) 544-7801", Address = "1005 W Burnside St", City = "Portland", State = "OR", Zip = "97214"},
                    new Business { BusinessId = 4, Name = "Hollywood Theatre", Category = "Entertainment", Description = "Historic movie house showing indie films.", Phone = "(503) 493-1128", Address = "4122 NE Sandy Blvd", City = "Portland", State = "OR", Zip = "97212"},
                    new Business { BusinessId = 5, Name = "Mississippi Studios", Category = "Entertainment", Description = "A restored church houses this intimate live music spot", Phone = "(503) 288-3895", Address = "3939 N Mississippi Ave", City = "Portland", State = "OR", Zip = "97227"},
                    new Business { BusinessId = 6, Name = "K&H Auto Shop", Category = "Service", Description = "Auto body shop.", Phone = "(971) 300-8228", Address = "6006 E Burnside St", City = "Portland", State = "OR", Zip = "97215"}
                    );
        }

        public DbSet<Business> Businesses { get; set; }
    }
}