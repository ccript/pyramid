using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using ObjectLayer;

namespace BuinessLayer
{
    public class LoginBLL
    {
        public static bool IsValidLogin(string Email, string Password)
        {
            return LoginDAL.IsValidLogin(Email, Password);

        }
        public static bool IsValidUserName(string Email)
        {
            return LoginDAL.IsValidUserName(Email);

        }
        public static string spellingSuggestion(string Email)
        {
            return LoginDAL.spellingSuggestion(Email);

        }

        public static bool IsValidPassword(string Password)
        {
            return LoginDAL.IsValidPassword(Password);

        }
        public static bool resetPassword(string Email, string Password)
        {
            return LoginDAL.resetPassword(Email, Password);

        }
        public static string genCode(string Email)
        {
            string randomCode = GetRandomPasswordUsingGUID(6);
            LoginDAL.saveCode(Email, randomCode);
            return randomCode;

        }
        public static string GetRandomPasswordUsingGUID(int length)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty);

            if (length <= 0 || length > guidResult.Length)
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

            return guidResult.Substring(0, length);
        }

        public static bool validateCode(string Email, string ResetCode)
        {
            return LoginDAL.validateCode(Email, ResetCode);
        }
        public static LoginBO getUserbyPhone(string Phone)
        {
            return LoginDAL.getUserbyPhone(Phone);
        }
        public static LoginBO getUserbyEmail(string Email)
        {
            return LoginDAL.getUserbyEmail(Email);
        }

        public static void saveIdentifyAccountInfo(string txtActiveEmail, string txtAccountEmail, string txtAccountUserName, string txtMobileNumber, string txtAccountLinkedEmailAddress)
        {
            LoginDAL.saveIdentifyAccountInfo(txtActiveEmail, txtAccountEmail, txtAccountUserName, txtMobileNumber, txtAccountLinkedEmailAddress);
        }
    }
}