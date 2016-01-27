using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment
{
    //Testing 
    class Author_Ex
    {
        private int exID = 0;
        private int authID = 0;
        private int authRank = 0;

        public int EX_ID
        {
            get { return exID; }
            set { exID = value; }
        }

        public int Author_ID
        {
            get { return authID; }
            set { authID = value; }
        }

        public int Rank
        {
            get { return authRank; }
            set { authRank = value; }
        }
    }
}
