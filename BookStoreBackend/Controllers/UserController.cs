using BusinessLayer.Interfaces;
using CommonLayer.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("Register")]
        public ActionResult UserRegister(UserDataModel usermodel)
        {
            try
            {
                var user = this.userBL.Register(usermodel);
                if (user != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfully", data = user });
                }
                return this.BadRequest(new { success = false, message = "Email Already Exits", data = user });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(LogInModel userLoginModel)
        {
            try
            {
                var result = this.userBL.UserLogin(userLoginModel);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Login Successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Login failed " });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("ForgotPassword")]
        public IActionResult UserForgotPassword(string Email)
        {
            try
            {
                if (Email == null)
                {
                    return this.BadRequest(new { success = false, Message = "Unsuccessful,Invalid EmailId" });
                }
                var result = this.userBL.UserForgotPassword(Email);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = "Something went wrong, Invalid EmailId" });
                }

                return this.Ok(new { success = true, Message = $"EMail has sent successfully to reset password" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("ResetPassword")]
        public IActionResult UserResetPassword(PasswordModel userPasswordModel)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var emailId = claims.Where(p => p.Type == @"Email").FirstOrDefault()?.Value;
                bool result = this.userBL.UserResetPassword(emailId, userPasswordModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, Message = $"Reset Password successful for EmailId:{emailId}..." });
                }

                return this.BadRequest(new { success = false, Message = $"Reset Password Unsuccessful for EmailId:{emailId}!!" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
