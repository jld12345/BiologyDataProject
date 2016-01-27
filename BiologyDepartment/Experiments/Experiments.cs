using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment
{
    public class Experiments
    {
        int exID = 0;
        string exAlias = "";
        string exTitle = "";
        string exSDate = "";
        string exEDate = "";
        string exHypo = "";

        public int ID
        {
            get { return exID; }
            set { exID = value; }
        }

        public string Alias
        {
            get { return exAlias; }
            set { exAlias = value; }
        }

        public string Title
        {
            get { return exTitle; }
            set { exTitle = value; }
        }

        public string SDate 
        {
            get { return exSDate; }
            set { exSDate = value; }
        }

        public string EDate 
        {
            get { return exEDate; }
            set { exEDate = value; }
        }

        public string Hypo 
        {
            get { return exHypo; }
            set { exHypo = value; }
        }

    }
}
