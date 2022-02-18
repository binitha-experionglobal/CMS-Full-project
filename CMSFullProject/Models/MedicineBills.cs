using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class MedicineBills
    {
        public int MedicineBillId { get; set; }
        public DateTime MedicineBillDateTime { get; set; }
        public int MedicineQuantity { get; set; }
        public int MedicineAmount { get; set; }
        public string MedicineName { get; set; }
        public int? PatientId { get; set; }
        public int? InventoryId { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual MedicineInventories Inventory { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual PrescribedMedicines Prescription { get; set; }
    }
}
