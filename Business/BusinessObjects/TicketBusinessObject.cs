using agap2it.labs.projects.PSM.Business.Base;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.Business.OperationResults;
using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessModels;
using agap2it.labs.projects.PSM.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Business.BusinessObjects
{
    public class TicketBusinessObject : BaseBusinessObject, ITicketBusinessObject
    {
        private readonly ITicketDataAccessObject _dataAccessObject;
        public TicketBusinessObject(ITicketDataAccessObject dataAccessObject)
        {
            _dataAccessObject = dataAccessObject;
        }
        public Task<OperationResult<Ticket>> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<TicketParkingSpotInfoDataAccessModel>>> GetTicketParkingSpotInfo()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Insert(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<Ticket>>> List()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(Ticket country)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(Ticket country)
        {
            throw new NotImplementedException();
        }
    }
}
