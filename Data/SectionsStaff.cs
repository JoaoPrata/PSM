using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class SectionsStaff
    {
        public long SectionId { get; set; }
        public long StaffId { get; set; }

        public virtual Floor Section { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
