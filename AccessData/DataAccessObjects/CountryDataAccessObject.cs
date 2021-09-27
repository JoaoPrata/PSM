using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.DataAccessObjects
{
    public class CountryDataAccessObject : ICountryDataAccessObject
    {
        /*public CountryDataAccessObject(ParkingServiceManagerContext context) : base(context)
        {

        }*/
        private readonly ParkingServiceManagerContext _context;
        public CountryDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }
        public async Task<Country> Get(long id)
        {
            var result = await _context.Countries.FindAsync(id);
            return result;
        }

        public void Insert(Country country)
        {
            country.Uuid = Guid.NewGuid();
            country.CreatedAt = DateTime.UtcNow;
            country.UpdatedAt = DateTime.UtcNow;
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Country>> List()
        {
            var result = await _context.Countries.ToListAsync();
            return result;
        }

        public async Task Remove(Country country)
        {
            country.IsDeleted = true;
            country.DeletedAt = DateTime.UtcNow;
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Update(Country country)
        {
            country.UpdatedAt = DateTime.UtcNow;
            _context.Countries.Update(country);
            _context.SaveChanges();
        }
    }
}
