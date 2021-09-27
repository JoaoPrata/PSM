using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.DataAccessModels
{
    public class TicketParkingSpotInfoDataAccessModel
    {
        public Guid Uuid { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Number { get; set; }
        public bool IsVacant { get; set; }
        public string Section { get; set; }
        public int Floor { get; set; }
    }
}
