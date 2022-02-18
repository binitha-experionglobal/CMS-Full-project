using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public class LabTechnicianRepository:ILabTechnicianRepository
    {
        private readonly CMSContext _db;

        public LabTechnicianRepository(CMSContext db)
        {
            _db = db;
        }
        #region Get Patient details using ID

        public async Task<TestReportViewModel>GetPatientDetails(int? id)
        {
            if (_db != null)
            {
                return await (
                    from testadvice in _db.TestAdvices
                    from testlist in _db.TestLists
                    from testdetails in _db.TestDetails
                    from unit in _db.Units
                    from patient in _db.Patients
                    from staff in _db.Staffs

                    where testadvice.AdviceId==testlist.AdviceId
                    && testlist.TestId==testdetails.TestId
                    && testdetails.UnitId==unit.UnitId
                    &&patient.PatientId==id
                    &&testadvice.StaffId==staff.StaffId
                    &&testadvice.PatientId==patient.PatientId
                    select new TestReportViewModel
                    {
                        PatientId=testadvice.PatientId,
                        PatientName=patient.PatientName,
                        StaffName=staff.StaffName,
                        AdviceId= (int)testlist.AdviceId,
                        ReportDateTime=testadvice.TestAdviceDateTime,
                        //MaximumValue=testdetails.MaximumValue,
                        //MinimumValue=testdetails.MinimumValue,
                       // UnitId=unit.UnitId,
                        //TestUnit=unit.TestUnit,
                        //TestAmount=testdetails.TestAmount,
                        //TestId= testlist.TestId,
                        PatientPhone=patient.PatientPhone,
                        TestListId=testlist.TestListId,
                        //TestName=testlist.TestName,

                        StaffId =staff.StaffId,

                    }
                    ).FirstOrDefaultAsync(); 
            }
            return null;
        }

        #endregion

        #region get details of tests

        public async Task<List<TestAmountViewModel>> GetTestDetails(int? id)
        {
            if (_db != null)
            {
                return await (
                    from testlist in _db.TestLists
                    from testdetails in _db.TestDetails
                    from unit in _db.Units
                    where testlist.AdviceId==id
                   && testlist.TestId==testdetails.TestId
                    &&testdetails.UnitId==unit.UnitId

                    select new TestAmountViewModel
                    {

                        MaximumValue = testdetails.MaximumValue,
                        MinimumValue = testdetails.MinimumValue,
                        UnitId = unit.UnitId,
                       TestUnit = unit.TestUnit,
                        AdviceId= (int)testlist.AdviceId,
                        TestAmount=testdetails.TestAmount,
                        TestId=testlist.TestId,

                        TestName=testlist.TestName




                    }
                    ).ToListAsync();
            }
            return null;
        }

        #endregion

        #region  list 


        public async Task<List<TestReportViewModel>> GetPatient(int? id)
        {
            if (_db != null)
            {
                return await (
                    from testadvice in _db.TestAdvices
                    from testlist in _db.TestLists
                    from testdetails in _db.TestDetails
                    from unit in _db.Units
                    from patient in _db.Patients
                    from staff in _db.Staffs

                    where testadvice.AdviceId == testlist.AdviceId
                    && testlist.TestId == testdetails.TestId
                    && testdetails.UnitId == unit.UnitId
                    && patient.PatientId == id
                    && testadvice.StaffId == staff.StaffId
                    && testadvice.PatientId == patient.PatientId
                    select new TestReportViewModel
                    {
                        PatientId = testadvice.PatientId,
                        PatientName = patient.PatientName,
                        StaffName = staff.StaffName,
                        AdviceId = (int)testlist.AdviceId,
                        ReportDateTime = testadvice.TestAdviceDateTime,
                        //MaximumValue=testdetails.MaximumValue,
                        //MinimumValue=testdetails.MinimumValue,
                        // UnitId=unit.UnitId,
                        //TestUnit=unit.TestUnit,
                        TestAmount=testdetails.TestAmount,
                        //TestId= testlist.TestId,
                        PatientPhone = patient.PatientPhone,
                        //TestListId=testlist.TestListId,
                        TestName=testlist.TestName,

                        StaffId = staff.StaffId,

                    }
                    ).ToListAsync();
            }
            return null;
        }


        #endregion

        #region Add Lab bills

        public async Task<int> AddBill(LabBills labbill)
        {
            if (_db != null)
            {
                await _db.LabBills.AddAsync(labbill);
                await _db.SaveChangesAsync();
                return labbill.LabBillId;
            }
            return 0;
        }

        #endregion

        #region Authentication

        public async Task<Authentications> GetUserByNameandPassword(string name, string password)
        {
            IQueryable<Authentications> result = _db.Authentications;
            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(e => e.UserName.Contains(name));
            }



            if (!string.IsNullOrEmpty(password))
            {
                result = result.Where(e => e.Password.Contains(password));
            }
            return await result.FirstOrDefaultAsync();
        }

        #endregion

        



    }
}
