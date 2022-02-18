using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class TestsViewModel
    {
        public int UnitId { get; set; }
        public string TestUnit { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
        public int TestAmount { get; set; }
    }
}
