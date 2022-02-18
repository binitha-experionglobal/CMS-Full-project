using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class MedicalHistory
    {
        public int MedicalListId { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public DateTime? DateTime { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
    }
}
