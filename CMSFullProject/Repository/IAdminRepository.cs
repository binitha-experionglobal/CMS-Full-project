using CMSFullProject.Models;
using CMSFullProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSFullProject.Repository
{
    public interface IAdminRepository
    {



        #region staffs

        //List from db
        Task<List<Staffs>> GetStaffs();

        //List from view model
        Task<List<StaffsVM>> listStaffs();


        //Get staff by id
        Task<ActionResult<Staffs>> GetStaffById(int? id);

        //Add staff to db
        Task<int> AddStaff(Staffs staff);

        //Update staff
        Task UpdateStaff(Staffs staff);
        #endregion


        #region Qualifications

        //List from db
        Task<List<Qualifications>> GetQualifications();
        #endregion


        #region Roles

        //List from db
        Task<List<Roles>> GetRoles();
        #endregion


    }
}
