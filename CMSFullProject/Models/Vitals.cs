using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class Vitals
    {
        public int VitalId { get; set; }
        public int BloodPressure { get; set; }
        public int PulseRate { get; set; }
        public int BodyTemp { get; set; }
        public int BreathRate { get; set; }
        public DateTime VitalDateTime { get; set; }
        public int? PatientId { get; set; }

        public virtual Patients Patient { get; set; }
    }
}
