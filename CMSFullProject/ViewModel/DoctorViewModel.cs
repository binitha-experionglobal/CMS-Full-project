using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.ViewModel
{
    public class DoctorViewModel
    {

        //role
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        //staff

        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffPhone { get; set; }
        public string StaffAddress { get; set; }
        public string StaffEmail { get; set; }
        public DateTime StaffDob { get; set; }
        public DateTime StaffJoiningDate { get; set; }

        //authentication

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //medical history
        public int MedicalListId { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }

        //patients

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientLocation { get; set; }
        public int PatientWeight { get; set; }
        public string PatientGender { get; set; }
        public string PatientBlood { get; set; }
        public DateTime PatientDob { get; set; }

        //prescribed medicines

        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDateTime { get; set; }

        //medicine details

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int MedicineQuantity { get; set; }
        public int MedicinePrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufacturingDate { get; set; }

        //medicine list

        public int MedicineListId { get; set; }
        public int Dosage { get; set; }
        public int Duration { get; set; }

        public DateTime TestAdviceDateTime { get; set; }
        public int TokenId { get; set; }
        public int? TokenNum { get; set; }
        public DateTime TokenDateTime { get; set; }
        public string TestName { get; set; }

    }
}
