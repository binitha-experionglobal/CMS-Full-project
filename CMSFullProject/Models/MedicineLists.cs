using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class MedicineLists
    {
        public int MedicineListId { get; set; }
        public string Dosage { get; set; }
        public int Duration { get; set; }
        public int? MedicineId { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual MedicineDetails Medicine { get; set; }
        public virtual PrescribedMedicines Prescription { get; set; }
    }
}
