using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.Interfaces
{
    public interface ITicketDataAccessObject : IBaseDataAccessObject<Ticket>
    {
        public Task<IEnumerable<TicketParkingSpotInfoDataAccessModel>> GetTicketsParkingSpots();
        public Task<Ticket> Get(Guid uuid);
    }
}
