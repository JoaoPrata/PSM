using agap2it.labs.projects.PSM.Business.Exceptions;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.Business.OperationResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.WebApp.Controllers
{
    [Route("ParkingSpots")]
    public class ParkingSpotController : Controller
    {
        private readonly IParkingSpotBusinessObject _parkingSpotBusinessObject;
        public ParkingSpotController(IParkingSpotBusinessObject parkingSpotBusinessObject)
        {
            _parkingSpotBusinessObject = parkingSpotBusinessObject;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var parkingSpotsListOperation = await _parkingSpotBusinessObject.ListParkingSpotsSectionsFloors();
            if (!parkingSpotsListOperation.IsSuccessful)
            {
                throw new RecordNotFoundException();
            }
            var parkingsSpotsInfo = parkingSpotsListOperation.Result;
            return View(parkingsSpotsInfo);

        }
    }
}
