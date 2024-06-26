using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using HotelListingAPI.Models.Hotel;
using HotelListingAPI.Models.User;

namespace HotelListingAPI.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();

        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();

        CreateMap<ApiUserDto, ApiUser>().ReverseMap();
    }   
}