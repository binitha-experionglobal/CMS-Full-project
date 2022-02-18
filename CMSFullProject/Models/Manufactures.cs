using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class Manufactures
    {
        public Manufactures()
        {
            MedicineInventories = new HashSet<MedicineInventories>();
        }

        public int ManufactureId { get; set; }
        public string ManufactureName { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureAddress { get; set; }

        public virtual ICollection<MedicineInventories> MedicineInventories { get; set; }
    }
}
