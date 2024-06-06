using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Jamaica",
                ShortName = "JM"
            },
            new Country
            {
                Id = 2,
                Name = "Guatemala",
                ShortName = "GT"
            },
            new Country
            {
                Id = 3,
                Name = "Panama",
                ShortName = "PTY"
            }
        );

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Saladitas Resort",
                Address = "Street 5, 4-Avenue, JM",
                CountryId = 1,
                Rating = 4.9
            },
            new Hotel
            {
                Id = 2,
                Name = "RIU Hotel",
                Address = "Street 55, 12-Avenue, Panama City",
                CountryId = 3,
                Rating = 4.5
            },
            new Hotel
            {
                Id = 3,
                Name = "Grand Tikal Futura Hotel",
                Address = "Street 12, 44-Avenue, Guatemala City",
                CountryId = 2,
                Rating = 4.8
            }
        );
    }
}