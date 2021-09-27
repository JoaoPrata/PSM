using agap2it.labs.projects.PSM.Business.Exceptions;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.WebApi.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.WebApi.Controllers
{
    [ApiController]
    [Route("Countries")]
    public class CountryController : Controller
    {
        private readonly ICountryBusinessObject _countryBusinessObject;
        public CountryController(ICountryBusinessObject countryBusinessObject)
        {
            _countryBusinessObject = countryBusinessObject;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<CountryResponse>>> List()
        {
            var countryListOperation = await _countryBusinessObject.List();
            if (!countryListOperation.IsSuccessful)
            {
                throw new RecordNotFoundException();
            }
            var countryList = countryListOperation.Result;
            var result = new List<CountryResponse>();
            foreach(var country in countryList)
            {
                result.Add(CountryResponse.From(country));
            }
            return Ok(result);
        }

        public async Task<IActionResult> Remove(long id)
        {
            var countryRemoveOperation = await _countryBusinessObject.Remove(id);
            if (!countryRemoveOperation.IsSuccessful)
            {
                throw new RecordNotFoundException();
            }
            return Ok();
        }

    }
}
