using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class PharmacistViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public int Duration { get; set; }
        public int MedicineId { get; set; }
    }
}
