using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessModels;
using agap2it.labs.projects.PSM.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace agap2it.labs.projects.PSM.DataAccess.DataAccessObjects
{
    public class BuildingDataAccessObject : IBuildingDataAccessObject
    {
        private readonly ParkingServiceManagerContext _context;

        public BuildingDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> List()
        {
            var result = await _context.Buildings.ToListAsync();
            return result;
        }

        public void Insert(Building building)
        {
            building.Uuid = Guid.NewGuid();
            building.CreatedAt = DateTime.UtcNow;
            building.UpdatedAt = DateTime.UtcNow;
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }
        public async Task<Building> Get(long id)
        {
            var result = await _context.Buildings.FindAsync(id);
            return result;
        }
        public void Update(Building building)
        {
            building.UpdatedAt = DateTime.UtcNow;
            _context.Buildings.Update(building);
            _context.SaveChanges();
        }
        public async Task Remove(Building building)
        {
            building.IsDeleted = true;
            building.DeletedAt = DateTime.UtcNow;
            _context.Entry(building).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<BuildingFloorsDataAccessModel>> GetBuildingFloors()
        {
            var result = await _context.Buildings.Include(b => b.Floors)
                                                 .Select(b => new BuildingFloorsDataAccessModel()
                                                 {
                                                     BuildingName = b.Name,
                                                     Floors = b.Floors.Select(f => f.Number)
                                                 }).ToListAsync();
            return result;
        }
    }
}
