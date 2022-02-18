using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class TestReports
    {
        public int ReportId { get; set; }
        public int PatientValue { get; set; }
        public string PatientName { get; set; }
        public DateTime ReportDateTime { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }
        public int? TestId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual TestDetails Test { get; set; }
    }
}
