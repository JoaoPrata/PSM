using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessModels;
using agap2it.labs.projects.PSM.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.DataAccessObjects
{
    public class FloorDataAccessObject : IFloorDataAccessObject
    {
        private readonly ParkingServiceManagerContext _context;
        public FloorDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Floor>> List()
        {
            var result = await _context.Floors.ToListAsync();
            return result;
        }
        public void Insert(Floor floor)
        {
            floor.Uuid = Guid.NewGuid();
            floor.CreatedAt = DateTime.UtcNow;
            floor.UpdatedAt = DateTime.UtcNow;
            _context.Add(floor);
            _context.SaveChanges();
        }
        public async Task<Floor> Get(long id)
        {
            var result = await _context.Floors.FindAsync(id);
            return result;
        }
        public void Update(Floor floor)
        {
            floor.UpdatedAt = DateTime.UtcNow;
            _context.Floors.Update(floor);
            _context.SaveChanges();
        }
        public async Task Remove(Floor floor)
        {
            floor.IsDeleted = true;
            floor.DeletedAt = DateTime.UtcNow;
            _context.Entry(floor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<FloorSectionsDataAccessModel>> GetFloorsSections()
        {
            var result = await _context.Floors.Include(f => f.Sections)
                                       .Select(f => new FloorSectionsDataAccessModel()
                                       {
                                           FloorNumber = f.Number,
                                           SectionLetters = f.Sections.Select(s => s.Letter)
                                       }).ToListAsync();
            return result;
        }
    } 
}
