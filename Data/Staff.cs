using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class Staff
    {
        public Staff()
        {
            SectionsStaffs = new HashSet<SectionsStaff>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<SectionsStaff> SectionsStaffs { get; set; }
    }
}
