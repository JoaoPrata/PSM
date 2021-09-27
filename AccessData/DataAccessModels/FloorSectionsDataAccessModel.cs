using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.DataAccessModels
{
    public class FloorSectionsDataAccessModel
    {
        public int FloorNumber { get; set; }
        public IEnumerable<string> SectionLetters { get; set; }
    }
}
