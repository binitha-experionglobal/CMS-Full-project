using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class TestDetails
    {
        public TestDetails()
        {
            TestLists = new HashSet<TestLists>();
            TestReports = new HashSet<TestReports>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
        public int TestAmount { get; set; }
        public int? UnitId { get; set; }

        public virtual Units Unit { get; set; }
        public virtual ICollection<TestLists> TestLists { get; set; }
        public virtual ICollection<TestReports> TestReports { get; set; }
    }
}
