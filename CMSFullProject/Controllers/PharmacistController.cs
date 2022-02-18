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
    public class PharmacistController : ControllerBase
    {

        private readonly IPharmacist _pharmacist;
        //constructor
        public PharmacistController(IPharmacist pharmacist)
        {
            _pharmacist = pharmacist;
        }
        #region Get Prescription
        [HttpGet]
        [Route("patients")]
        public async Task<IActionResult> GetPrescriptions(int patientId)
        {
            if (patientId == 0)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _pharmacist.GetPrescription(patientId);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Create bills
        [HttpPost]
        [Route("patients")]
        public async Task<IActionResult> CreateBills([FromBody] MedicineBills bill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bills = await _pharmacist.CreatePharmacyBill(bill);
                    if (bills > 0)
                    {
                        return Ok();
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineBills>>> GetAllBills()
        {
            return await _pharmacist.GetAllBill();
        }



        #endregion


        #region
        [HttpGet]
        [Route("getmedicinelist/{id}")]
        public async Task<IActionResult> GetMedicines(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _pharmacist.GetMedicineList(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        #endregion
    }
}
