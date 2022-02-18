using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class TestReportViewModel
    {
        public int AdviceId { get; set; }   //connect
       // public DateTime TestAdviceDateTime { get; set; }
        public int? PatientId { get; set; } //connect
        public int? StaffId { get; set; }   //connect
        //public int ReportId { get; set; }   //post report
        //public int PatientValue { get; set; }   //report
        public string PatientName { get; set; } //report&bill
        public DateTime ReportDateTime { get; set; }    //report
        public int? TestId { get; set; }    //connect table
        public int TestListId { get; set; } //connect table
        public string TestName { get; set; }    //report & bill
        public int MaximumValue { get; set; }   //report
        public int MinimumValue { get; set; }   //report
        public int TestAmount { get; set; } //for bill
        public int? UnitId { get; set; }    //for connecting tables
        public string StaffName { get; set; }   //for report
        public string PatientPhone { get; set; }    //for report &bill
        public string TestUnit { get; set; }    //for report


    }
}
