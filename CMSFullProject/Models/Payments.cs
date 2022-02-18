using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public string PaymentMode { get; set; }
        public int? TransactionNumber { get; set; }
        public DateTime PaymentsDateTime { get; set; }
        public int? PatientId { get; set; }

        public virtual Patients Patient { get; set; }
    }
}
