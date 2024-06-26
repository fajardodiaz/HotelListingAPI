using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingAPI.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
}
