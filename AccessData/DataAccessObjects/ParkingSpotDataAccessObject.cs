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
    public class ParkingSpotDataAccessObject : IParkingSpotDataAccessObject
    {
        private readonly ParkingServiceManagerContext _context;
        public ParkingSpotDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }
        public async Task<ParkingSpot> Get(long id)
        {
            var result = await _context.ParkingSpots.FindAsync(id);
            return result;
        }

        public async Task<ParkingSpot> Get(Guid Uuid)
        {
            var result = await _context.ParkingSpots.FindAsync(Uuid);
            return result;
        }

        public async Task<ParkingSpotSectionFloorModel> GetParkingSpotSectionFloor(long id)
        {
            var result = await _context.ParkingSpots.Where(p => p.Id == id)
                                                    .Select(p => new ParkingSpotSectionFloorModel()
                                                    {
                                                        Uuid = p.Uuid,
                                                        Number = p.Number,
                                                        IsVacant = p.IsVacant,
                                                        Section = p.Section.Letter,
                                                        Floor = p.Section.Floor.Number
                                                    }).FirstOrDefaultAsync();
            return result;
        }

        public void Insert(ParkingSpot parkingSpot)
        {
            parkingSpot.Uuid = Guid.NewGuid();
            parkingSpot.CreatedAt = DateTime.UtcNow;
            parkingSpot.UpdatedAt = DateTime.UtcNow;
            _context.ParkingSpots.Add(parkingSpot);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ParkingSpot>> List()
        {
            var result = await _context.ParkingSpots.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ParkingSpotSectionFloorModel>> ListParkingSpotsSectionsFloors()
        {
            var result = await _context.ParkingSpots.Select(p => new ParkingSpotSectionFloorModel()
                                                                    {
                                                                        Uuid = p.Uuid,
                                                                        Number = p.Number,
                                                                        IsVacant = p.IsVacant,
                                                                        Section = p.Section.Letter,
                                                                        Floor = p.Section.Floor.Number
                                                                    }).ToListAsync();
            return result;
        }

        public async Task Remove(ParkingSpot parkingSpot)
        {
            parkingSpot.IsDeleted = true;
            parkingSpot.DeletedAt = DateTime.UtcNow;
            _context.Entry(parkingSpot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Update(ParkingSpot parkingSpot)
        {
            parkingSpot.UpdatedAt = DateTime.UtcNow;
            _context.ParkingSpots.Update(parkingSpot);
            _context.SaveChanges();
        }
    }
}
