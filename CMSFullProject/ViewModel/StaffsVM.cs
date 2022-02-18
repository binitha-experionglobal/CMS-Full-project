using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class StaffsVM
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffPhone { get; set; }
        public string StaffAddress { get; set; }
        public string StaffEmail { get; set; }
        public DateTime StaffDob { get; set; }
        public DateTime StaffJoiningDate { get; set; }
        public string RoleName { get; set; }
        public string QualificationName { get; set; }
    }
}
