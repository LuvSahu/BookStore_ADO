using BusinessLayer.Interfaces;
using CommonLayer.UserModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserDataModel Register(UserDataModel usermodel)
        {
            try
            {
                return userRL.Register(usermodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UserLogin(LogInModel userLoginModel)
        {
            try
            {
                return this.userRL.UserLogin(userLoginModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UserForgotPassword(string Email)
        {
            try
            {
                return this.userRL.UserForgotPassword(Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UserResetPassword(string Email, PasswordModel userPasswordModel)
        {
            try
            {
                return this.userRL.UserResetPassword(Email, userPasswordModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

