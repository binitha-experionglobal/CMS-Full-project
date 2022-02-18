using CMSFullProject.Models;
using CMSFullProject.Repository;
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
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionist _rec;

        public ReceptionistController(IReceptionist rec)
        {
            _rec = rec;
        }


        #region Get Token Queue

        // GET: api/Receptionist/tokenqueue
        [HttpGet]
        [Route("TokenQueue")]
        public async Task<IActionResult> GetTokenQueue()
        {
            try
            {
                var patients = await _rec.GetTokenQueue();
                if (patients == null)
                {
                    return NotFound();
                }
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region Get patient by Id Token list

        // GET: api/Receptionist/patient---->id
        [HttpGet]
        [Route("patient")]
        public async Task<IActionResult> GetPatient(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _rec.GetPatient(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest("There is an error");
            }
        }
        #endregion

        #region Get patient by Id For insertion and deletion

        // GET: api/Receptionist/patientid
        [HttpGet]
        [Route("patientid")]
        public async Task<IActionResult> GetPatients(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _rec.GetPatientDetails(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest("There is an error");
            }
        }
        #endregion

        #region Update patient

        // PUT: api/Receptionist/updatepatient
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Patients patients)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _rec.UpdatePatient(patients);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Add Patient

        // POST: api/Receptionist/addpatient
        [HttpPost]
        [Route("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] Patients patients)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var patientid = await _rec.AddPatient(patients);
                    if (patientid > 0)
                    {
                        return Ok(patientid);
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

        #region Generate Token

        // POST: api/Receptionist/token
        [HttpPost("Token")]
        public async Task<IActionResult> GenerateToken(Tokens token)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tokenid = await _rec.GenerateToken(token);
                    if (tokenid > 0)
                    {
                        return Ok(tokenid);
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

        #region Payment History

        // GET: api/Receptionist/Payments
        [HttpGet("Payments")]
        public async Task<IActionResult> GetPaymentHistory()
        {
            try
            {
                var payments = await _rec.GetPaymentHistory();
                if (payments == null)
                {
                    return NotFound();
                }
                return Ok(payments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Consultation Bills

        // POST: api/Receptionist/generatebill
        [HttpPost("GenerateBill")]
        public async Task<IActionResult> PostCosnultationBill([FromBody] ConsultationBills bills)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var billId = await _rec.PostCosnultationBill(bills);
                    if (billId > 0)
                    {
                        return Ok(billId);
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

        #region Get all patients

        //HttpMethod: api/receptionist/getallpatients
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _rec.GetAllPatients();
                if (patients == null)
                {
                    return NotFound();
                }
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Get Patients from view model

        //HttpMethod: api/receptionist/patients
        [HttpGet("Patients")]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await _rec.GetPatients();
                if (patients == null)
                {
                    return NotFound();
                }
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Doctors list from view model

        //HTTP: api/receptionist/doctors
        [HttpGet("Doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctors = await _rec.GetDoctors();
                if (doctors == null)
                {
                    return NotFound();
                }
                return Ok(doctors);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete token

        //Method: /api/receptionist/deletetoken
        [HttpDelete("DeleteToken/{id}")]
        public async Task<IActionResult> DeleteToken(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _rec.DeleteToken(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();        //return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
