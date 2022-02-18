using CMSFullProject.Models;
using CMSFullProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSFullProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTechnicianController : ControllerBase
    {
        private readonly ILabTechnicianRepository _lab;
        private readonly IConfiguration _config;

        public LabTechnicianController(ILabTechnicianRepository lab, IConfiguration config)
        {
            _lab = lab;
            _config = config;
        }

        #region Get patient by Id 

        // ROUTE: api/labtechnician/getpatient

        [HttpGet]
        [Route("getpatient")]
        public async Task<IActionResult> GetPatients(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _lab.GetPatientDetails(id);
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

        #region Get test details

        // ROUTE: api/labtechnician/GetTestDetails

        [HttpGet]
        [Route("GetTestDetails")]
        public async Task<IActionResult> GetTestDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _lab.GetTestDetails(id);
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

        #region trial

        // ROUTE: api/labtechnician/getpatient

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetPatient(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _lab.GetPatient(id);
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

        #region Add Lab bills

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddLabbills([FromBody] LabBills labbill)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _lab.AddBill(labbill);
                    if (Id > 0)
                    {
                        return Ok(Id);
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

        //get user by username and password https://localhost:44310/api/users/login/sanu&sanu
        #region getuser token
        [HttpGet("{Login}/{name}&{password}")]
        //[AllowAnonymous]
        public async Task<ActionResult> GetUserByNameandPassword(string name, string password)
        {
            #region token



            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials);
            var response = Ok(new { token = ' ', employee = ' ' });



            if (ModelState.IsValid)
            {
                try
                {
                    var tokens = new JwtSecurityTokenHandler().WriteToken(token);
                    var result = await _lab.GetUserByNameandPassword(name, password);
                    response = Ok(new { token = tokens, UserName = result.UserName, UserPassword = result.Password, StaffId = result.StaffId, UserId = result.UserId});
                    return response;
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        #endregion






    }
}
