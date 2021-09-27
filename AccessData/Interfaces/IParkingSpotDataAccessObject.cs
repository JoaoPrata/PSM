using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.Interfaces
{
    public interface IParkingSpotDataAccessObject : IBaseDataAccessObject<ParkingSpot>
    {
        public Task<IEnumerable<ParkingSpotSectionFloorModel>> ListParkingSpotsSectionsFloors();
        public Task<ParkingSpotSectionFloorModel> GetParkingSpotSectionFloor(long id);
        public Task<ParkingSpot> Get(Guid Uuid);
    }
}
