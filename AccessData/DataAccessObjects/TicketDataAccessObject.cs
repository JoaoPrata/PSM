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
    public class TicketDataAccessObject : ITicketDataAccessObject
    {
        private readonly ParkingServiceManagerContext _context;
        public TicketDataAccessObject(ParkingServiceManagerContext context)
        {
            _context = context;
        }
        public async Task<Ticket> Get(long id)
        {
            var result = await _context.Tickets.FindAsync(id);
            return result;
        }

        public async Task<Ticket> Get(Guid uuid)
        {
            var result = await _context.Tickets.FindAsync(uuid);
            return result;
        }

        public async Task<IEnumerable<TicketParkingSpotInfoDataAccessModel>> GetTicketsParkingSpots()
        {
            var result = await _context.Tickets.Include(t => t.ParkingSpot)
                                       .Select(t => new TicketParkingSpotInfoDataAccessModel()
                                       {
                                           Uuid = t.Uuid,
                                           CheckIn = t.CheckIn,
                                           CheckOut = t.CheckOut,
                                           Number = t.ParkingSpot.Number,
                                           IsVacant = t.ParkingSpot.IsVacant,
                                           Section = t.ParkingSpot.Section.Letter,
                                           Floor = t.ParkingSpot.Section.Floor.Number
                                       }).ToArrayAsync();
            return result;
        }

        public void Insert(Ticket ticket)
        {
            ticket.CreatedAt = DateTime.UtcNow;
            ticket.UpdatedAt = DateTime.UtcNow;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Ticket>> List()
        {
            var result = await _context.Tickets.ToListAsync();
            return result;
        }

        public async Task Remove(Ticket ticket)
        {
            ticket.IsDeleted = true;
            ticket.DeletedAt = DateTime.UtcNow;
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Update(Ticket ticket)
        {
            ticket.UpdatedAt = DateTime.UtcNow;
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    }
}
