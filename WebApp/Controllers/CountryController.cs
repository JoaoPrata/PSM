using agap2it.labs.projects.PSM.Business.Exceptions;
using agap2it.labs.projects.PSM.Business.Interfaces;
using agap2it.labs.projects.PSM.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace agap2it.labs.projects.PSM.WebApp.Controllers
{
    [Route("Countries")]
    public class CountryController : Controller
    {
        private readonly ICountryBusinessObject _countryBusinessObject;
        public CountryController(ICountryBusinessObject countryBusinessObject)
        {
            _countryBusinessObject = countryBusinessObject;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countryListOperation = await _countryBusinessObject.List();
            if (!countryListOperation.IsSuccessful)
            {
                throw new RecordNotFoundException();
            }
            var countryList = countryListOperation.Result;
            return View(countryList);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Country country)
        {
            var countryCreateOperation = await _countryBusinessObject.Insert(country);
            if (!countryCreateOperation.IsSuccessful)
            {
                throw new RecordNotFoundException();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
