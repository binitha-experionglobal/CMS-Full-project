using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public interface ILabTechnicianRepository
    {
        //get patient by id 
        Task<TestReportViewModel> GetPatientDetails(int? id);
    
        //get test details using advice id
        Task<List<TestAmountViewModel>> GetTestDetails(int? id);

        //get patient by id 
        Task<List<TestReportViewModel>>GetPatient(int? id);

        //add lab bill
        Task<int> AddBill(LabBills labbill);

        Task<Authentications> GetUserByNameandPassword(string name, string password);




    }
}
