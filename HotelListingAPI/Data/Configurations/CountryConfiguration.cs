using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingAPI.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
