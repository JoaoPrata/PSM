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
    public interface IParkingSpotBusinessObject
    {
        public Task<OperationResult<ParkingSpotSectionFloorModel>> TakeTicket();
        public Task<OperationResult<IEnumerable<ParkingSpot>>> List();
        public Task<OperationResult> Insert(ParkingSpot parkingSpot);
        public Task<OperationResult<ParkingSpot>> Get(long id);
        public Task<OperationResult> Update(ParkingSpot parkingSpot);
        public Task<OperationResult> Remove(ParkingSpot parkingSpot);
        public Task<OperationResult> Remove(long id);
        public Task<OperationResult<IEnumerable<ParkingSpotSectionFloorModel>>> ListParkingSpotsSectionsFloors();

    }
}
