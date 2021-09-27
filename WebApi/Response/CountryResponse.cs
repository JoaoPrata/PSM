using agap2it.labs.projects.PSM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.WebApi.Response
{
    public class CountryResponse
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public static CountryResponse From(Country country)
        {
            return new CountryResponse()
            {
                Name = country.Name,
                CountryCode = country.CountryCode,
                Uuid = country.Uuid
            };
        }
    }
}
