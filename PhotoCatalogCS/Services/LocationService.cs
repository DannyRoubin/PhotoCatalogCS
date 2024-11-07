using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoCatalogCS.Data;
using PhotoCatalogCS.Models;

namespace PhotoCatalogCS.Services
{
    public class LocationService
    {
        private readonly PhotoCatalogContext _context;

        public LocationService(PhotoCatalogContext context)
        {
            _context = context;
        }

        // Get all locations
        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        // Get a specific location by ID
        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        // Add a new location
        public async Task<Location> AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        // Update an existing location
        public async Task<Location> UpdateLocationAsync(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }

        // Delete a location by ID
        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null) return false;

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
