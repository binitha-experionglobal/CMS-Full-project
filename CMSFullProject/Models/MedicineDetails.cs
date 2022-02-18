using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class MedicineDetails
    {
        public MedicineDetails()
        {
            MedicineInventories = new HashSet<MedicineInventories>();
            MedicineLists = new HashSet<MedicineLists>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int MedicineQuantity { get; set; }
        public int MedicinePrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? ManufacturingDate { get; set; }

        public virtual ICollection<MedicineInventories> MedicineInventories { get; set; }
        public virtual ICollection<MedicineLists> MedicineLists { get; set; }
    }
}
