using agap2it.labs.projects.PSM.Business.Base;
using agap2it.labs.projects.PSM.Business.Exceptions;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.Business.OperationResults;
using agap2it.labs.projects.PSM.Data;
using agap2it.labs.projects.PSM.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Business.BusinessObjects
{
    public class CountryBusinessObject : BaseBusinessObject, ICountryBusinessObject
    {
        private readonly ICountryDataAccessObject _dataAccessObject;
        public CountryBusinessObject(ICountryDataAccessObject dataAccessObject)
        {
            _dataAccessObject = dataAccessObject;
        }
        public async Task<OperationResult<Country>> Get(long id)
        {
            return await ExecuteOperation(async() =>
            {
                return await _dataAccessObject.Get(id);
            });
        }

        public async Task<OperationResult> Insert(Country country)
        {
            return await ExecuteOperation(async () =>
            {
                var countries = await _dataAccessObject.List();
                if(countries.Any(x => x.Name == country.Name))
                {
                    throw new RepeatedRecordException();
                }
                _dataAccessObject.Insert(country);
            });
        }

        public async Task<OperationResult<IEnumerable<Country>>> List()
        {
            return await ExecuteOperation(async() =>
            {
                return await _dataAccessObject.List();
            });
        }
        public async Task<OperationResult<int>> Count()
        {
            return await ExecuteOperation(async () =>
            {
                var result = await _dataAccessObject.List();
                var count = result.Count();
                return count;
            });
        }

        public async Task<OperationResult> Remove(Country country)
        {
            return await ExecuteOperation(async () =>
            {
                await _dataAccessObject.Remove(country);
            });
        }
        public async Task<OperationResult> Remove(long id)
        {
            return await ExecuteOperation(async () =>
            {
                var country = _dataAccessObject.Get(id).Result;
                if (country == null)
                {
                    throw new RecordNotFoundException();
                }
                await _dataAccessObject.Remove(country);
            });
        }

        public async Task<OperationResult> Update(Country country)
        {
            return await ExecuteOperation(async () =>
            {
                _dataAccessObject.Update(country);
            });
        }
    }
}
