using agap2it.labs.projects.PSM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.WebApi.Requests
{
    public class CountryRequest
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public Country ToCountry()
        {
            return new Country()
            {
                Name = this.Name,
                CountryCode = this.CountryCode
            };
        }
    }
}
