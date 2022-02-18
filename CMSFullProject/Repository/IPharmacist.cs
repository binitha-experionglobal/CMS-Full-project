using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public interface IPharmacist
    {
        // Retrieve patient prescription
        Task<PharmacistViewModel> GetPrescription(int patientId);

        //Create medicine bill
        Task<int> CreatePharmacyBill(MedicineBills bill);


        Task<List<MedicineBills>> GetAllBill();

        Task<List<PharmacyList>> GetMedicineList(int? id);
    }
}
