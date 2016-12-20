using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;


namespace BiologyDepartment.Data
{
    public class ExperimentData
    {
        public int ExperimentID { get; set; }
        public int JsonID { get; set; }
        public string JSON { get; set; }
        public DateTime	CreateDate { get; set; }
	    public string CreatedUser { get; set; }
	    public DateTime ModifiedDate { get; set; }
	    public string ModifiedUser { get; set; }
	    public DateTime DeletedDate { get; set; }
        public string DeletedUser { get; set; }
        public DataTable JSONTable { get; set; }
        public string TableFilter { get; set; }
        public int TableRow { get; set; }

        public ExperimentData() { }

        public void DeSerializeJsonToDataTable()
        {
            try
            {

                GlobalVariables.CustomColumns = null;
                GlobalVariables.CustomColumns = GlobalVariables.GlobalConnection.GetColumns();
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
                        {
                            foreach (CustomColumns c in GlobalVariables.CustomColumns)
                            {
                                if(c.ColName.ToUpper().Equals(jproperty.Name))
                                    switch (c.ColDataType.ToUpper()) 
                                    { 
                                        case "INTEGER":
                                            result.Columns.Add(jproperty.Name, typeof(Int32));
                                            break;
                                        case "DECIMAL":
                                        case "FORMULA":
                                            result.Columns.Add(jproperty.Name, typeof(Decimal));
                                            break;
                                        default:
                                            result.Columns.Add(jproperty.Name, typeof(string));
                                            break;
                                    }
                                
                            }
                        }
                        
                    }
                }
                foreach (CustomColumns c in GlobalVariables.CustomColumns)
                {
                    if (!result.Columns.Contains(c.ColName))
                    {
                        switch (c.ColDataType.ToUpper())
                        {
                            case "INTEGER":
                            case "DECIMAL":
                            case "FORMULA":
                                result.Columns.Add(c.ColName, typeof(float));
                                break;
                            default:
                                result.Columns.Add(c.ColName, typeof(string));
                                break;
                        }
                    }
                }
                result.Columns.Add("EXPERIMENTS_JSONB_ID", typeof(string));

                foreach (var row in theArray)
                {
                    var datarow = result.NewRow();
                    foreach (var jToken in row)
                    {
                        var jProperty = jToken as JProperty;
                        if (jProperty == null) continue;
                        string sType = "";
                        if(result.Columns.Contains(jProperty.Name) && result.Columns[jProperty.Name].DataType != null)
                            sType = result.Columns[jProperty.Name].DataType.ToString();
                        if(sType.Equals("System.Single") && !string.IsNullOrEmpty(jProperty.Value.ToString()))
                            datarow[jProperty.Name] = Convert.ToDecimal(jProperty.Value.ToString());
                        else if (sType.Equals("System.Single") && string.IsNullOrEmpty(jProperty.Value.ToString()))
                            datarow[jProperty.Name] = 0;
                        else if(sType.Equals("System.Int32") && !string.IsNullOrEmpty(jProperty.Value.ToString()))
                            datarow[jProperty.Name] = Convert.ToInt32(jProperty.Value.ToString());
                        else if (sType.Equals("System.Int32") && !string.IsNullOrEmpty(jProperty.Value.ToString()))
                            datarow[jProperty.Name] = 0;
                        else if (!string.IsNullOrEmpty(jProperty.Value.ToString()))
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
                MessageBox.Show("Error deserializng the data.  Please contact support.", "Deserialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SerializeDataToJSON()
        {
            if (JSONTable != null)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(JSONTable.Copy());
                JSON = JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
        }
    }
}
