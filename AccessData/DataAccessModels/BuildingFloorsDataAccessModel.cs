using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.DataAccessModels
{
    public class BuildingFloorsDataAccessModel
    {
        public string BuildingName { get; set; }
        public IEnumerable<int> Floors { get; set; }
    }
}
