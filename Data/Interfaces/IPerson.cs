using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Data.Interfaces
{
    public interface IPerson : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
