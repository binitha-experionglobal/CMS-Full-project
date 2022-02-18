using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public class Receptionist:IReceptionist
    {
        private readonly CMSContext _db;

        public Receptionist(CMSContext db)
        {
            _db = db;
        }
        #region Get Token Queue

        //Get Token Queue
        public async Task<List<ReceptionistViewModel>> GetTokenQueue()
        {
            if (_db != null)
            {
                var currentYear = DateTime.Now.Year;

                return await (
                    from p in _db.Patients
                    from t in _db.Tokens
                    from d in _db.Staffs
                    where t.PatientId == p.PatientId && t.StaffId == d.StaffId
                    select new ReceptionistViewModel
                    {
                        PatientId = p.PatientId,
                        PatientName = p.PatientName,
                        TokenNumber = (int)t.TokenNum,
                        Age = (currentYear - p.PatientDob.Year),
                        DoctorName = d.StaffName
                    }
                    ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Patient

        //Add a new patient
        public async Task<int> AddPatient(Patients patients)
        {
            if (_db != null)
            {
                await _db.Patients.AddAsync(patients);
                await _db.SaveChangesAsync();
                return patients.PatientId;
            }
            return 0;
        }
        #endregion

        #region Get Patient by id

        //Get patient by id using view model
        public async Task<ReceptionistViewModel> GetPatient(int? id)
        {
            if (_db != null)
            {
                return await (
                    from p in _db.Patients
                    where p.PatientId == id
                    select new ReceptionistViewModel
                    {
                        PatientId = p.PatientId,
                        PatientName = p.PatientName
                    }
                    ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Get Patient details for insertion and deletion

        public async Task<PatientsViewModel> GetPatientDetails(int? id)
        {
            if (_db != null)
            {
                return await (
                    from p in _db.Patients
                    where p.PatientId == id
                    select new PatientsViewModel
                    {
                        PatientId = p.PatientId,
                        PatientName = p.PatientName,
                        PatientGender = p.PatientGender,
                        PatientLocation = p.PatientLocation,
                        PatientPhone = p.PatientPhone,
                        PatientWeight = p.PatientWeight,
                        PatientBlood = p.PatientBlood,
                        PatientDob = p.PatientDob

                    }
                    ).FirstOrDefaultAsync();
            }
            return null;
        }

        #endregion

        #region Update Patient

        //Update a patient
        public async Task UpdatePatient(Patients patients)
        {
            if (_db != null)
            {
                _db.Entry(patients).State = EntityState.Modified;
                _db.Patients.Update(patients);
                await _db.SaveChangesAsync();
            }
        }
        #endregion

        #region Generate Token

        //Generate token 
        public async Task<int> GenerateToken(Tokens token)
        {
            if (_db != null)
            {
                await _db.Tokens.AddAsync(token);
                await _db.SaveChangesAsync();
                return (int)token.TokenNum;
            }
            return 0;
        }
        #endregion

        #region Payment History

        //Get payment History
        public async Task<List<ReceptionPaymentViewModel>> GetPaymentHistory()
        {
            if (_db != null)
            {
                int currentYear, patientYear, age;
                currentYear = DateTime.Today.Year;      //Get today's year
                Patients patients = new Patients();
                patientYear = patients.PatientDob.Year;    //Get patient year
                age = currentYear - patientYear;
                return await (from p in _db.Patients
                              from pay in _db.Payments
                              where pay.PatientId == p.PatientId
                              select new ReceptionPaymentViewModel
                              {
                                  InvoiceNumber = (int)pay.TransactionNumber,
                                  DateTime = pay.PaymentsDateTime,
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  Age = age,
                                  PaymentMode = pay.PaymentMode
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Consultation Bills

        //Generate Consultation Bills
        public async Task<int> PostCosnultationBill(ConsultationBills bills)
        {
            if (_db != null)
            {
                await _db.ConsultationBills.AddAsync(bills);
                await _db.SaveChangesAsync();
                return bills.ConsultationAmount;
            }
            return 0;
        }
        #endregion

        #region Get all patients

        //Get list of all patients

        public async Task<List<Patients>> GetAllPatients()
        {
            if (_db != null)
            {
                return await _db.Patients.ToListAsync();
            }
            return null;
        }


        #endregion

        #region Get patients view model

        //Get list of all patients using view model
        public async Task<List<PatientsViewModel>> GetPatients()
        {
            if (_db != null)
            {
                return await (
                    from p in _db.Patients
                    select new PatientsViewModel
                    {
                        PatientId = p.PatientId,
                        PatientName = p.PatientName,
                        PatientPhone = p.PatientPhone,
                        PatientLocation = p.PatientLocation,
                        PatientBlood = p.PatientBlood,
                        PatientGender = p.PatientGender,
                        PatientWeight = p.PatientWeight,
                        PatientDob = p.PatientDob
                    }
                    ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Doctors List

        //List doctors from view model

        public async Task<List<DoctorsViewModel>> GetDoctors()
        {
            return await (
                from d in _db.Staffs
                from r in _db.Roles
                from q in _db.Qualifications
                where r.RoleId == d.RoleId && q.QualificationId == d.QualificationId && r.RoleName == "Doctor"
                select new DoctorsViewModel
                {
                    DoctorId = d.StaffId,
                    DoctorName = d.StaffName,
                    Phone = d.StaffPhone,
                    Email = d.StaffEmail,
                    Qualification = q.QualificationName,
                    RoleName = r.RoleName
                }

                ).ToListAsync();
        }
        #endregion

        #region Delete token

        public async Task<int> DeleteToken(int? id)
        {
            int result = 0;
            if (_db != null)
            {
                var tokens = await _db.Tokens.FirstOrDefaultAsync(token => token.TokenId == id);
                if (tokens != null) //Check condition
                {
                    //Delete
                    _db.Tokens.Remove(tokens);

                    //Commiting to change the physical db
                    result = await _db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion
    }
}
