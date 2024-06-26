using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using HotelListingAPI.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(ApplicationDbContext context, IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountry()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var countryList = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(countryList);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            
            if (country == null)
            {
                return NotFound();
            }
            
            var record = _mapper.Map<CountryDto>(country);
            
            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto countryDto)
        {
            if (id != countryDto.Id)
            {
                return BadRequest("Invalid Record ID");
            }

            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(countryDto, country);
            
            try
            {
                await _countriesRepository.UpdateAsync(country);
                return Accepted();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                { 
                    throw;
                }
            }

        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateCountryDto>> PostCountry(CreateCountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles="Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);
            return Accepted();

        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
