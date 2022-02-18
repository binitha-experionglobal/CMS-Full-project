using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class TestAdvices
    {
        public TestAdvices()
        {
            TestLists = new HashSet<TestLists>();
        }

        public int AdviceId { get; set; }
        public DateTime TestAdviceDateTime { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual ICollection<TestLists> TestLists { get; set; }
    }
}
