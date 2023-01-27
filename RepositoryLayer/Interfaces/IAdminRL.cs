using CommonLayer.AdminModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRL
    {
        public string AdminLogin(AdminLoginModel adminLoginModel);
    }
}
