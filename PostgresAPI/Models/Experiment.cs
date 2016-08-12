using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PostgresAPI.Models
{
    public class Experiment
    {
        public int ExperimentID { get; set; }
        public int JSON_ID { get; set; }
        public string JSON { get; set; }
        public string JSONB { get; set; }
        public DataSet JsonDS { get; set; }
    }
}