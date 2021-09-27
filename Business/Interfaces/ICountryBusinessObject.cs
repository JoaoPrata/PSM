using agap2it.labs.projects.PSM.Business.OperationResults;
using agap2it.labs.projects.PSM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Business.Interfaces
{
    public interface ICountryBusinessObject
    {
        public Task<OperationResult<IEnumerable<Country>>> List();
        public Task<OperationResult> Insert(Country country);
        public Task<OperationResult<Country>> Get(long id);
        public Task<OperationResult> Update(Country country);
        public Task<OperationResult> Remove(Country country);
        public Task<OperationResult> Remove(long id);

    }
}
