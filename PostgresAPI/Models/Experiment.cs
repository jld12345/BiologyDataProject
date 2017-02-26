using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Serialization;

namespace PostgresAPI.Models
{
    [JsonObject]
    public class Experiment
    {
        [JsonProperty("ExperimentID")]
        public int ExperimentID { get; set; }
        
        [JsonProperty("JSON")]
        public string JSON { get; set; }

        [JsonProperty("JSONTableSerialized")]
        public string JSONTableSerialized { get; set; }
        
        [JsonProperty("JSONTable")]
        public DataTable JSONTable { get; set; }

        [JsonProperty("ShortName")]
        public string ShortName { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("Notes")]
        public string Notes { get; set; }

        [JsonProperty("ParentExperiment")]
        public int ParentExperiment { get; set; }

        [JsonProperty("UserAccess")]
        public string UserAccess { get; set; }

        public Experiment() { }

        public void DeSerializeJsonToDataTable()
        {
            try
            {
                JArray theArray = JArray.Parse(JSON);
                var result = new DataTable();
                //Initialize the columns, If you know the row type, replace this   
                foreach (var row in theArray)
                {
                    foreach (var jToken in row)
                    {
                        var jproperty = jToken as JProperty;
                        if (jproperty == null) continue;
                        if (result.Columns[jproperty.Name] == null)
                            result.Columns.Add(jproperty.Name, typeof(string));
                    }
                }
                foreach (var row in theArray)
                {
                    var datarow = result.NewRow();
                    foreach (var jToken in row)
                    {
                        var jProperty = jToken as JProperty;
                        if (jProperty == null) continue;
                        datarow[jProperty.Name] = jProperty.Value.ToString();
                    }
                    result.Rows.Add(datarow);
                }

                //data = JsonConvert.DeserializeObject<DataSet>(theArray.ToString());
                if (result != null)
                {
                    DataColumn[] keys = new DataColumn[1];
                    keys[0] = result.Columns["EXPERIMENTS_JSONB_ID"];
                    result.PrimaryKey = keys;
                    JSONTable = result.Copy();
                }
                else
                    JSONTable = null;
            }
            catch
            {
                JSONTable = null;
            }
        }

        public void SerializeDataToJSON()
        {
            if (JSONTable != null)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(JSONTable.Copy());
                JSONTableSerialized = JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
        }
    }
}