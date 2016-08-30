using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment.ExperimentDocuments
{
    public class DocumentClass
    {
        public int DOCUMENT_ID { get; set; }
        public int EXPERIMENT_ID { get; set; }
	    public string DOCUMENT_TITLE { get; set; }
	    public string DOCUMENT_DESCRIPTION { get; set; }
        public string DOCUMENT_TYPE { get; set; }
        public byte[] DOCUMENT { get; set; }

        public DocumentClass()
        {

        }
    }
}
