using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class Building
    {
        public Building()
        {
            Floors = new HashSet<Floor>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Name { get; set; }
        public long DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
    }
}
