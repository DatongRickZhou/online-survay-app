using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week2
{
    public class User
    {
        int userID;
        string FirstName;
        string LastName;
        DateTime DOB;
        string PhoneNumber;
        public User(int id,string firstname,string lastname,DateTime dob,string phonenumber) {
            this.userID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.DOB = dob;
            this.PhoneNumber = phonenumber;
        }
        public User(int id) {
            this.userID = id;
        }
        public int getUserID() {
            return userID;
        }
    }
}