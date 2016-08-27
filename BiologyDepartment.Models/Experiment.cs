using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using BiologyDepartmentModels.Utilities;

namespace BiologyDepartmentModels
{
    [JsonObject]
    public class Experiment
    {
        [JsonProperty("ExperimentID")]
        public int ExperimentID { get; set; }
        
        [JsonProperty("JSON_ID")]
        public int JSON_ID { get; set; }
        
        [JsonProperty("JSON")]
        public string JSON { get; set; }
        
        [JsonProperty("JSONB")]
        public string JSONB { get; set; }

        [JsonProperty("JsonDS")]
        public DataSet JsonDS { get; set; }
    }
}