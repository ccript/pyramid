using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ObjectLayer
{
    
    public class UserFriendsBO
    {


        public string Id { get; set; }
        public string UserId { get; set; }
        public string FriendUserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }
        public string BelongsTo { get; set; }
        public string MutualFriendName { get; set; }
        public int MutualFriendsCount { get; set; }
        public string Hometown { get; set; }
        public string DateOfBirth { get; set; }
        ArrayList emps = new ArrayList();

        public ArrayList Employers
        {
            get { return emps; }
            set { emps = value; }
        }
        //public ArrayList Employers {get { return Employers; }}
        public string Employer { get; set; }
        public string Education { get; set; }
        public string Location { get; set; }
        public int Score { get; set; }

    }

}