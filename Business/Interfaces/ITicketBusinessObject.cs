using agap2it.labs.projects.PSM.Business.OperationResults;
using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Business.Interfaces
{
    public interface ITicketBusinessObject
    {
        public Task<OperationResult<IEnumerable<Ticket>>> List();
        public Task<OperationResult> Insert(Ticket ticket);
        public Task<OperationResult<Ticket>> Get(long id);
        public Task<OperationResult> Update(Ticket ticket);
        public Task<OperationResult> Remove(Ticket ticket);
        public Task<OperationResult> Remove(long id);
        public Task<OperationResult<IEnumerable<TicketParkingSpotInfoDataAccessModel>>> GetTicketParkingSpotInfo();
    }
}
