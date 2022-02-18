using System;
using System.Collections.Generic;

namespace CMSFullProject.Models
{
    public partial class Patients
    {
        public Patients()
        {
            ConsultationBills = new HashSet<ConsultationBills>();
            DoctorNote = new HashSet<DoctorNote>();
            LabBills = new HashSet<LabBills>();
            MedicalHistory = new HashSet<MedicalHistory>();
            MedicineBills = new HashSet<MedicineBills>();
            Payments = new HashSet<Payments>();
            PrescribedMedicines = new HashSet<PrescribedMedicines>();
            TestAdvices = new HashSet<TestAdvices>();
            TestReports = new HashSet<TestReports>();
            Tokens = new HashSet<Tokens>();
            Vitals = new HashSet<Vitals>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientLocation { get; set; }
        public int PatientWeight { get; set; }
        public string PatientGender { get; set; }
        public string PatientBlood { get; set; }
        public DateTime PatientDob { get; set; }

        public virtual ICollection<ConsultationBills> ConsultationBills { get; set; }
        public virtual ICollection<DoctorNote> DoctorNote { get; set; }
        public virtual ICollection<LabBills> LabBills { get; set; }
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
        public virtual ICollection<MedicineBills> MedicineBills { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<PrescribedMedicines> PrescribedMedicines { get; set; }
        public virtual ICollection<TestAdvices> TestAdvices { get; set; }
        public virtual ICollection<TestReports> TestReports { get; set; }
        public virtual ICollection<Tokens> Tokens { get; set; }
        public virtual ICollection<Vitals> Vitals { get; set; }
    }
}
