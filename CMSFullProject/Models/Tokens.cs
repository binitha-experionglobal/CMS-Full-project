using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class Tokens
    {
        public int TokenId { get; set; }
        public int? TokenNum { get; set; }
        public DateTime TokenDateTime { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
    }
}
