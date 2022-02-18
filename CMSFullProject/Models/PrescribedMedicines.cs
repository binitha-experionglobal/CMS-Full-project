using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class PrescribedMedicines
    {
        public PrescribedMedicines()
        {
            MedicineBills = new HashSet<MedicineBills>();
            MedicineLists = new HashSet<MedicineLists>();
        }

        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDateTime { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual ICollection<MedicineBills> MedicineBills { get; set; }
        public virtual ICollection<MedicineLists> MedicineLists { get; set; }
    }
}
