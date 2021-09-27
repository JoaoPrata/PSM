using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class ParkingSpot
    {
        public ParkingSpot()
        {
            Tickets = new HashSet<Ticket>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public int Number { get; set; }
        public bool IsVacant { get; set; }
        public long SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
