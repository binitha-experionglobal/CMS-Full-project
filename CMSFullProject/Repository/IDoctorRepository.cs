using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public interface IDoctorRepository
    {
        //retrieves patient data

        Task<DoctorViewModel> GetPatient(int? patientId);

        // retrieves patient token
        Task<List<DoctorViewModel>> GetTokenList();

        //Doctor access doctors note
        Task<int> CreateDoctorNote(MedicalHistory note);

        //Doctor records the vitals of patient
        Task<int> PostVitals(Patients patient);

        //Doctor prescribes medicine
        Task<int> PostMedicine(DoctorViewModel medicine);

        //Doctor advises lab test

        Task<int> PostLabTest(DoctorViewModel labTest);

        // get test list with units
        Task<List<TestsViewModel>> GetTestListWithUnits();


        //Doctor records the vitals of patient
        Task<int> PostVitals(Vitals vitals);

        //List vitals
        Task<List<Vitals>> GetVitalsList();

        //Creates Test Advice Id
        Task<int> CreateTestAdviceId(TestAdvices testAdvice);

        //Doctor Adds Tests
        Task<int>AddTest(TestLists testList);

        //Testname listing in doctor page
        Task<List<TestDetailsViewModel>> ListTests();




    }
}
