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
    public class SectionDataAccessObject : ISectionDataAccessObject
    {
        private readonly ParkingServiceManagerContext _context;
        public SectionDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }
        public async Task<Section> Get(long id)
        {
            var result = await _context.Sections.FindAsync(id);
            return result;
        }

        public void Insert(Section section)
        {
            section.Uuid = Guid.NewGuid();
            section.CreatedAt = DateTime.UtcNow;
            section.UpdatedAt = DateTime.UtcNow;
            _context.Sections.Add(section);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Section>> List()
        {
            var result = await _context.Sections.ToListAsync();
            return result;
        }

        public async Task Remove(Section section)
        {
            section.IsDeleted = true;
            section.DeletedAt = DateTime.UtcNow;
            _context.Entry(section).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Update(Section section)
        {
            section.UpdatedAt = DateTime.UtcNow;
            _context.Sections.Update(section);
            _context.SaveChanges();
        }
    }
}
