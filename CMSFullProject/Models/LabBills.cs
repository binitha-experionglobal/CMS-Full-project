using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class LabBills
    {
        public int LabBillId { get; set; }
        public DateTime LabBillDateTime { get; set; }
        public int LabBillAmount { get; set; }
        public int? TestListId { get; set; }
        public int? PatientId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual TestLists TestList { get; set; }
    }
}
