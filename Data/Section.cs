using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class Section
    {
        public Section()
        {
            ParkingSpots = new HashSet<ParkingSpot>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Letter { get; set; }
        public long FloorId { get; set; }

        public virtual Floor Floor { get; set; }
        public virtual ICollection<ParkingSpot> ParkingSpots { get; set; }
    }
}
