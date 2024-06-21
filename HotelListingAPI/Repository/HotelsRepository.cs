using HotelListingAPI.Contracts;
using HotelListingAPI.Data;

namespace HotelListingAPI.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
