using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class District
    {
        public District()
        {
            Buildings = new HashSet<Building>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
