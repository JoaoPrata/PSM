using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.DataAccess.Interfaces
{
    public interface IBaseDataAccessObject<T>
    {
        public Task<IEnumerable<T>> List();
        public void Insert(T record);
        public Task<T> Get(long id);
        public void Update(T record);
        public Task Remove(T record);
    }
}
