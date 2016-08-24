using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment.ExperimentDocuments
{
    public class PDFClass
    {
        public int EXPERIMENT_PDF_ID { get; set; }
        public int EXPERIMENT_ID { get; set; }
	    public string EXPERIMENT_PDF_TITLE { get; set; }
	    public string EXPERIMENT_PDF_DESCRIPTION { get; set; }
        public byte[] EXPERIMENT_PDF { get; set; }

        public PDFClass()
        {

        }
    }
}
