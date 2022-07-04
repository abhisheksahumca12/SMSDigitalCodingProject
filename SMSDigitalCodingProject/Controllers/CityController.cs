using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSDigitalCodingProject.Model;
using SMSDigitalCodingProject.Respository;

namespace SMSDigitalCodingProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityDetailRepo _ICity;
        private readonly ILogger _logger;
        
        public CityController(ILogger<CityController> logger, ICityDetailRepo ICity)
        {
            _logger = logger;
            _ICity = ICity;
        }

        // GET: api/cities
        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = await _ICity.GetCityDetails();
                if (cities == null)
                {
                    _logger.LogInformation("No Cities found in record");
                    return NotFound();
                }
                _logger.LogInformation("Total {0} cities found", cities.Count());
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        // GET api/GetCity
        [HttpGet]
        [Route("GetCity/{id:int}")]
        public async Task<IActionResult> GetCity(int id)
        {
            if (id == null)
            {
                _logger.LogInformation("No id found with {0}", id);
                return BadRequest();
            }

            try
            {
                var city = await _ICity.GetCityDetailById(id);

                if (city == null)
                {
                    _logger.LogInformation("No City found with id {0}", id);
                    return NotFound();
                }
                _logger.LogInformation("cities found with id {0}", id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        // POST api/AddCity
        [HttpPost]
        [Route("AddCity")]
        public async Task<IActionResult> AddCity(CityDetail city)
        {
            try
            {
                var Id = await _ICity.AddCityDetail(city);
                if (Id > 0)
                {
                    _logger.LogInformation("City {0} Added successfully", city.City);
                    return Ok(Id);
                }
                else
                {
                    _logger.LogInformation("No City Added");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        // POST api/UpdateCity/5
        [HttpPut]
        [Route("UpdateCity")]
        public async Task<IActionResult> UpdateCity(CityDetail city)
        {
            try
            {
                await _ICity.UpdateCityDetail(city);
                _logger.LogInformation("City {0} updated successfully", city.City);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    _logger.LogInformation("{0} occured ", ex.GetType().Name);
                    return NotFound();
                }
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/DeleteCity/5
        [HttpDelete]
        [Route("DeleteCity/{id:int}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            int result = 0;

            if (id == null)
            {
                _logger.LogInformation("City with id {0} not found", id);
                return BadRequest();
            }

            try
            {
                result = await _ICity.DeleteCityDetail(id);
                if (result == 0)
                {
                    _logger.LogInformation("City with id {0} not deleted", id);
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }
    }
}
