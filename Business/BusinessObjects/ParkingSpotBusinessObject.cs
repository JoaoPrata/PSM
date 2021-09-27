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
    public class ParkingSpotBusinessObject : BaseBusinessObject, IParkingSpotBusinessObject
    {
        private readonly IParkingSpotDataAccessObject _dataAccessObject;
        public ParkingSpotBusinessObject(IParkingSpotDataAccessObject dataAccessObject)
        {
            _dataAccessObject = dataAccessObject;
        }
        public Task<OperationResult<ParkingSpot>> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Insert(ParkingSpot parkingSpot)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ParkingSpot>>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<IEnumerable<ParkingSpotSectionFloorModel>>> ListParkingSpotsSectionsFloors()
        {
            return await ExecuteOperation(async () =>
            {
                return await _dataAccessObject.ListParkingSpotsSectionsFloors();
            });
        }

        public Task<OperationResult> Remove(ParkingSpot parkingSpot)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<ParkingSpotSectionFloorModel>> TakeTicket()
        {
            return await ExecuteOperation(() =>
            {
                var parkingSpots = _dataAccessObject.List().Result;
                var vacantParkingSpots = parkingSpots.Where(p => p.IsVacant).ToList();
                var vacantParkinSpotId = vacantParkingSpots.FirstOrDefault().Id;
                var vacantParkingSpot = _dataAccessObject.Get(vacantParkinSpotId).Result;
                vacantParkingSpot.IsVacant = false;
                _dataAccessObject.Update(vacantParkingSpot);
                return _dataAccessObject.GetParkingSpotSectionFloor(vacantParkingSpot.Id);
            });
        }

        public Task<OperationResult> Update(ParkingSpot parkingSpot)
        {
            throw new NotImplementedException();
        }
    }
}
