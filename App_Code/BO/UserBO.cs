using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ObjectLayer
{

    public class UserBO
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsMobileAlert { get; set; }

        public string PasswordResetCode { get; set; }

        public bool UserStatus { get; set; }


    }

}