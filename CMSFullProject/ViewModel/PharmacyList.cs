using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class PharmacyList
    {
        //prescription

        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDateTime { get; set; }

        //list

        public int MedicineListId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public int Duration { get; set; }
        public int MedicineId { get; set; }

        //medicine details
        public int MedicineQuantity { get; set; }
        public int MedicinePrice { get; set; }
    }
}
