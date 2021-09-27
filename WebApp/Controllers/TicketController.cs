using agap2it.labs.projects.PSM.Business.Exceptions;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.WebApp.Controllers
{
    
    [Route("Tickets")]
    public class TicketController : Controller
    {
        private readonly IParkingSpotBusinessObject _parkingSpotBusinessObject;
        public TicketController(IParkingSpotBusinessObject parkingSpotBusinessObject)
        {
            _parkingSpotBusinessObject = parkingSpotBusinessObject;
        }
        [HttpGet("TakeTicket")]
        public async Task<IActionResult> Index()
        {
            var parkingSpotListOperation = await _parkingSpotBusinessObject.TakeTicket();
            if (!parkingSpotListOperation.IsSuccessful)
            {
                throw new RecordNotFoundException();
            }
            var parkingsSpotsInfo = parkingSpotListOperation.Result;
            return View(parkingsSpotsInfo);

        }
    }
    
}
