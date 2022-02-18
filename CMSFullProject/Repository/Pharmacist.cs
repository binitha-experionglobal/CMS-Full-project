using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public class Pharmacist:IPharmacist

    {
    
        private readonly CMSContext _context;

        //default constructor injection
        public Pharmacist(CMSContext context)
        {
            _context = context;
        }
        #region Get Prescription
        public async Task<PharmacistViewModel> GetPrescription(int patientId)
        {
            if (_context != null)
            {
                //linq 
                return await (from a in _context.PrescribedMedicines
                              from b in _context.Patients
                              from c in _context.MedicineLists
                              from d in _context.MedicineDetails
                              where a.PatientId == patientId
                              select new PharmacistViewModel
                              {
                                  PatientId = b.PatientId,
                                  PatientName = b.PatientName,
                                  MedicineId = c.MedicineListId,
                                  MedicineName = d.MedicineName,
                                  Dosage = c.Dosage,
                                  Duration = c.Duration
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        #region generate bill

        public async Task<int> CreatePharmacyBill(MedicineBills bill)
        {
            if (_context != null)
            {
                await _context.MedicineBills.AddAsync(bill);
                await _context.SaveChangesAsync();
                return bill.MedicineBillId;
            }
            return 0;
        }
        #endregion



        public async Task<List<MedicineBills>> GetAllBill()
        {
            if (_context != null)
            {
                return await _context.MedicineBills.ToListAsync();
            }
            return null;
        }


        #region Get Medicine List



        public async Task<List<PharmacyList>> GetMedicineList(int? id)
        {
            if (_context != null)
            {
                return await (
                from list in _context.MedicineLists
                from details in _context.MedicineDetails
                where list.PrescriptionId == id
                && list.MedicineId == details.MedicineId
                select new PharmacyList
                {
                    MedicineId = (int)list.MedicineId,
                    MedicineName = details.MedicineName,
                    Dosage = list.Dosage,
                    Duration = list.Duration,
                    MedicinePrice = details.MedicinePrice



                }
                ).ToListAsync();
            }
            return null;



        }




        #endregion







    }
}
