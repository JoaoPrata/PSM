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
    public class DistrictDataAccessObject : IDistrictDataAccessObject
    {
        private readonly ParkingServiceManagerContext _context;
        public DistrictDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }
        public async Task<District> Get(long id)
        {
            var result = await _context.Districts.FindAsync(id);
            return result;
        }

        public void Insert(District district)
        {
            district.Uuid = Guid.NewGuid();
            district.CreatedAt = DateTime.UtcNow;
            district.UpdatedAt = DateTime.UtcNow;
            _context.Districts.Add(district);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<District>> List()
        {
            var result = await _context.Districts.ToListAsync();
            return result;
        }

        public async Task Remove(District district)
        {
            district.IsDeleted = true;
            district.DeletedAt = DateTime.UtcNow;
            _context.Entry(district).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Update(District district)
        {
            district.UpdatedAt = DateTime.UtcNow;
            _context.Districts.Update(district);
            _context.SaveChangesAsync();
        }
    }
}
