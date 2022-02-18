using CMSFullProject.Models;
using CMSFullProject.Repository;
using CMSFullProject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        //data member

        private readonly IDoctorRepository _doctorRepository;

        //constructor

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }



        //get user by username
        [HttpGet]
        [Route("patient/getpatient")]

        public async Task<IActionResult> GetPatient(int? patientId)
        {
            if (patientId == null)
            {
                return BadRequest();
            }
            try
            {
                var patient_data = await _doctorRepository.GetPatient(patientId);
                if (patient_data == null)
                {
                    return NotFound();
                }
                return Ok(patient_data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #region Get token List
        [HttpGet]
        [Route("tokens/tokenlist")]
        public async Task<IActionResult> GetTokens()
        {
            try
            {
                var tokens = await _doctorRepository.GetTokenList();
                if (tokens == null)
                {
                    return NotFound();
                }
                return Ok(tokens);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region medicine prescription
        [HttpPost]
        [Route("medicines/medicine")]
        public async Task<IActionResult> PostMedicine([FromBody] DoctorViewModel medicine)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var medId = await _doctorRepository.PostMedicine(medicine);
                    if (medId > 0)
                    {
                        return Ok(medId);
                    }
                    else
                    {
                        return NotFound();

                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion

        #region lab test
        [HttpPost]
        [Route("tests/test")]
        public async Task<IActionResult> PostLabTest([FromBody] DoctorViewModel labTest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var testId = await _doctorRepository.PostLabTest(labTest);
                    if (testId > 0)
                    {
                        return Ok(testId);
                    }
                    else
                    {
                        return NotFound();

                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion

        #region Medical history/Doctor note
        [HttpPost]
        [Route("patient/medicalhistory")]
        public async Task<IActionResult> AddDoctorNote([FromBody] MedicalHistory patient)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientId = await _doctorRepository.CreateDoctorNote(patient);
                    if (patientId > 0)
                    {
                        return Ok(patientId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Post vitals

        //Methods: /api/doctors/vitals
        [HttpPost("Vitals")]
        public async Task<IActionResult> PostVitals([FromBody] Vitals vitals)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var vitalsId = await _doctorRepository.PostVitals(vitals);
                    if (vitalsId > 0)
                    {
                        return Ok(vitalsId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region List vitals

        [HttpGet]
        [Route("GetVitals")]
        public async Task<IActionResult> GetVitals()
        {
            try
            {
                var vitals = await _doctorRepository.GetVitalsList();
                if (vitals == null)
                {
                    return NotFound();
                }
                return Ok(vitals);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Create Test Advice Id

        //ROUTE: api/doctor/CreateTestListId
        [HttpPost]
        [Route("CreateTestListId")]
        public async Task<IActionResult> CreateTestListId([FromBody] TestAdvices testAdvice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var testListid = await _doctorRepository.CreateTestAdviceId(testAdvice);
                    if (testListid > 0)
                    {
                        return Ok(testListid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Doctor adds Test

        //ROUTE: api/doctor/AddTest
        [HttpPost]
        [Route("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] TestLists testlist)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var testListid = await _doctorRepository.AddTest(testlist);
                    if (testListid > 0)
                    {
                        return Ok(testListid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region List test
        //ROUTE: api/doctor/viewlists
        [HttpGet]
        [Route("ViewLists")]
        public async Task<IActionResult> ListTests()
        {
            try
            {
                var list = await _doctorRepository.ListTests();
                if (list == null)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
