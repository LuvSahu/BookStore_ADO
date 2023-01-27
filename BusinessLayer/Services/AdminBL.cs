using BusinessLayer.Interfaces;
using CommonLayer.AdminModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }
        public string AdminLogin(AdminLoginModel adminLoginModel)
        {
            try
            {
                return this.adminRL.AdminLogin(adminLoginModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

