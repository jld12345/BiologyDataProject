using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment
{
    public class Author
    {
        string authLName = "";
        string authFName = "";
        string authMI = "";
        string authEmail = "";
        string authAssoc = "";
        string authDept = "";
        string authPic = "";
        int authID = 0;

        public string LastName
        { 
            get { return authLName; }
            set { authLName = value; }
        }

        public string FirstName
        {
            get { return authFName; }
            set { authFName = value; }
        }

        public string MI
        {
            get { return authMI; }
            set { authMI = value; }
        }

        public string Email
        {
            get { return authEmail; }
            set { authEmail = value; }
        }

        public string Association
        {
            get { return authAssoc; }
            set { authAssoc = value; }
        }

        public string Department
        {
            get { return authDept; }
            set { authDept = value; }
        }

        public string Picture
        {
            get { return authPic; }
            set { authPic = value; }
        }

        public int ID
        {
            get { return authID; }
            set { authID = value; }
        }
     }
}
