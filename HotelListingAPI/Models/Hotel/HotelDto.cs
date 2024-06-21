using HotelListingAPI.Models.Country;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListingAPI.Models.Hotel;

public class HotelDto : BaseHotelDto
{
    public int Id { get; set; }
}