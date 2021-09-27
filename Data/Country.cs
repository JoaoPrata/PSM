using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class Country
    {
        public Country()
        {
            Districts = new HashSet<District>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
