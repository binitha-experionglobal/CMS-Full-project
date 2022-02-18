using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class ReceptionistViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int TokenNumber { get; set; }
        public int Age { get; set; }
        public string DoctorName { get; set; }
    }
}
