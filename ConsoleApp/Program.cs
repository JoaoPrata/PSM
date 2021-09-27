using agap2it.labs.projects.PSM.Business.BusinessObjects;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.DataAccessObjects;
using agap2it.labs.projects.PSM.DataAccess.Interfaces;
using System;
using System.Linq;

namespace agap2it.labs.projects.PSM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ctx = new ParkingServiceManagerContext();
            ITicketDataAccessObject tdao = new TicketDataAccessObject(ctx);
            IDistrictDataAccessObject ddao = new DistrictDataAccessObject(ctx);
            IBuildingDataAccessObject bdao = new BuildingDataAccessObject(ctx);
            IFloorDataAccessObject fdao = new FloorDataAccessObject(ctx);
            ISectionDataAccessObject sdao = new SectionDataAccessObject(ctx);
            IParkingSpotDataAccessObject pdao = new ParkingSpotDataAccessObject(ctx);
            ICountryDataAccessObject cdao = new CountryDataAccessObject(ctx);
            IParkingSpotBusinessObject pbo = new ParkingSpotBusinessObject(pdao);


            var result = pbo.TakeTicket();
            var p = result.Result;
            Console.WriteLine(p);
            

        }
    }
}
