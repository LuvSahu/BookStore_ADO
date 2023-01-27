using BusinessLayer.Interfaces;
using CommonLayer.AdminModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost("Login")]
        public IActionResult UserLogin(AdminLoginModel adminLoginModel)
        {
            try
            {
                var result = this.adminBL.AdminLogin(adminLoginModel);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "Login Failed" });
                }

                return this.Ok(new { success = true, Message = "Admin Login Sucessfully", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
