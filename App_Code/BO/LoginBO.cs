using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Class1
/// </summary>

namespace ObjectLayer
{

    public class LoginBO
    {
        //
        // TODO: Add constructor logic here
        //

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}