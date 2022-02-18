using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class TestLists
    {
        public TestLists()
        {
            LabBills = new HashSet<LabBills>();
        }

        public int TestListId { get; set; }
        public string TestName { get; set; }
        public int? AdviceId { get; set; }
        public int? TestId { get; set; }

        public virtual TestAdvices Advice { get; set; }
        public virtual TestDetails Test { get; set; }
        public virtual ICollection<LabBills> LabBills { get; set; }
    }
}
