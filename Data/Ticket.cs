using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class Ticket
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public long ParkingSpotId { get; set; }

        public virtual ParkingSpot ParkingSpot { get; set; }
    }
}
