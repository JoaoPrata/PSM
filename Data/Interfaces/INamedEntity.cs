using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Data.Interfaces
{
    public interface INamedEntity : IEntity
    {
        public string Name { get; set; }
    }
}
