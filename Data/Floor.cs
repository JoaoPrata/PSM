using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class Floor
    {
        public Floor()
        {
            Sections = new HashSet<Section>();
            SectionsStaffs = new HashSet<SectionsStaff>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public int Number { get; set; }
        public long BuildingId { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<SectionsStaff> SectionsStaffs { get; set; }
    }
}
