using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoCatalogCS.Models;
using PhotoCatalogCS.Services;

namespace PhotoCatalogCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/location/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        // POST: api/location
        [HttpPost]
        public async Task<ActionResult<Location>> AddLocation(Location location)
        {
            var createdLocation = await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocation), new { id = createdLocation.LocationId }, createdLocation);
        }

        // PUT: api/location/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            if (id != location.LocationId)
                return BadRequest();

            var updatedLocation = await _locationService.UpdateLocationAsync(location);
            return Ok(updatedLocation);
        }

        // DELETE: api/location/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var deleted = await _locationService.DeleteLocationAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
