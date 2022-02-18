using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class PatientsViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientLocation { get; set; }
        public DateTime PatientDob { get; set; }
        public string PatientGender { get; set; }
        public string PatientBlood { get; set; }
        public int PatientWeight { get; set; }
    }
}
