using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class TestAmountViewModel
    {
        public string TestUnit { get; set; }    //for report
        public int? TestId { get; set; }    //connect table
        public int TestListId { get; set; } //connect table
        public string TestName { get; set; }    //report & bill
       public int MaximumValue { get; set; }   //report
       public int MinimumValue { get; set; }   //report
        public int TestAmount { get; set; } //for bill
        public int? UnitId { get; set; }    //for connecting tables
        public int AdviceId { get; set; }   //connect
    }
}
