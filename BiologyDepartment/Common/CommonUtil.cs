using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DocumentFormat.OpenXml;
using System.IO;
using BiologyDepartment.Misc_Files;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;

using Excel;

namespace BiologyDepartment.Common
{
    class CommonUtil
    {
        #region Private Variables
        daoSetup _daoSetup = new daoSetup();
        daoData _daoData = new daoData();
        #endregion
        public CommonUtil() { }

        //<Summary>
        //The validateData method is used to verify the data before adding/updating the data table.
        //It takes the input table to check, the datagridview for the columns, a bool value to bypass the validation,
        //and a bool value for update or adding the rows.  The datagridview may be null.
        //</Summary
        public DataTable ValidateData(DataTable dtInput, DataGridView dgvColumns, bool bIsChecked, bool bIsUpdate)
        {
            Stopwatch sw = new Stopwatch();
            DataTable dtNotInserted;
            Dictionary<string, string> deCols = new Dictionary<string, string>();
            List<string> ImportRows = new List<string>();
            List<AnimalData> theAnimals = new List<AnimalData>();
            bool bUseMapCol = true;

            sw.Start();

            if (!dtInput.Columns.Contains("DataID"))
                dtInput.Columns.Add("DataID");
            if (!dtInput.Columns.Contains("ExcludeRow"))
                dtInput.Columns.Add("ExcludeRow");

            if (dgvColumns == null)
            {
                dgvColumns = new DataGridView();
                dgvColumns.DataSource = _daoSetup.GetExperimentColumns(GlobalVariables.Experiment.ID);
                bUseMapCol = false;
            }
            DataTable dgvTable = (DataTable)dgvColumns.DataSource;
            foreach (DataRow dgvr in dgvTable.Rows)
            {
                if (dgvr["custom_column_name"] == DBNull.Value ||
                    dgvr["custom_columns_id"] == DBNull.Value ||
                    dgvr["custom_column_data_type"] == DBNull.Value ||
                    (bUseMapCol && dgvr["map_column"] == DBNull.Value))
                {
                    string sMsg = "Cannot import data at this time.  Please verify that all columns have been mapped and imported.";
                    MessageBox.Show(sMsg, "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string col = Convert.ToString(dgvr["custom_column_name"]);
                string colId = Convert.ToString(dgvr["custom_columns_id"]);

                string mapCol = "";
                if (bUseMapCol)
                    mapCol = Convert.ToString(dgvr["map_column"]);
                else
                    mapCol = Convert.ToString(dtInput.Rows[0][Convert.ToString(dgvr["custom_columns_id"])]);
                if (!string.IsNullOrEmpty(mapCol) && !string.IsNullOrEmpty(col) && !string.IsNullOrEmpty(colId))
                {
                    col = colId + "|" + col + "|" + Convert.ToString(dgvr["custom_column_data_type"]);
                    deCols.Add(mapCol, col);
                }
            }

            dtNotInserted = dtInput.Clone();

            foreach (DataRow dr in dtInput.Rows)
            {
                bool bIsValid = false;
                string values = "";
                foreach (KeyValuePair<string, string> entry in deCols)
                {
                    DateTime tempDate;
                    bIsValid = false;
                    double tempDouble = 0;
                    int tempInt = 0;
                    string[] subItem = entry.Value.Split('|');
                    string cellVal = "";
                    if (bUseMapCol)
                        cellVal = Convert.ToString(dr[entry.Key]);
                    else
                        cellVal = entry.Key;
                if(bIsChecked)
                {
                    switch (subItem[2])
                    {
                        case "DECIMAL":
                            if (!string.IsNullOrEmpty(cellVal) && Double.TryParse(cellVal, out tempDouble))
                                bIsValid = true;
                            break;
                        case "INTEGER":
                            if (!string.IsNullOrEmpty(cellVal) && Int32.TryParse(cellVal, out tempInt))
                                bIsValid = true;
                            break;
                        case "DATE_TIME":
                            if (!string.IsNullOrEmpty(cellVal) && DateTime.TryParse(cellVal, out tempDate))
                                bIsValid = true;
                            break;
                        default:
                            bIsValid = true;
                            break;
                    }
                }
                else
                    bIsValid = true;

                    if (bIsValid)
                    {
                        values = values + "|^|" + subItem[0] + "^*^" + cellVal;
                    }
                    else
                    {
                        DataRow newRow = dtNotInserted.NewRow();
                        for (int i = 0; i < newRow.ItemArray.Length; i++)
                        {
                            newRow[i] = dr[i];
                        }
                        dtNotInserted.Rows.Add(newRow);
                        break;
                    }
                }
                if (bIsValid && !bIsUpdate)
                {
                    ImportRows.Add(values);
                }
                else if(bIsValid && bIsUpdate)
                {
                    AnimalData animal = new AnimalData();
                    animal.DataAgg = values;
                    animal.DataID = Convert.ToInt32(dr["DataID"]);
                    animal.ExID = GlobalVariables.Experiment.ID;
                    animal.ExcludeRow = Convert.ToString(dr["ExcludeRow"]);
                    animal.ModUser = GlobalVariables.ADUserName;
                    animal.Picture = dr["1"] as byte[];
                    _daoData.UpdateExperimentData(animal);
                    if (animal.Picture != null)
                        _daoData.InsertPic("EXPERIMENT_DATA", animal.DataID, animal.Picture);
                    ImportRows.Add(values);
                }
            }

            if (ImportRows.Count > 0 && !bIsUpdate)
            {
                _daoSetup.BulkImport(ImportRows);  
            }

            sw.Stop();
            Trace.WriteLine("Import time elapsed:  " + sw.Elapsed);

            string msg2 = ImportRows.Count.ToString() + " were imported.  ";
            if (dtNotInserted.Rows.Count > 0  && !bIsUpdate)
            {

                msg2 = msg2 + dtNotInserted.Rows.Count.ToString() + " were determined to have errors and were not imported/added.  " +
                    "Please verify the data is correct and try to import/add again.  Pressing Yes will bypass the Data checks.  " +
                    "Do you wish to enter the data in its current state?";
            }
            if (dtNotInserted.Rows.Count > 0 && bIsUpdate)
            {

                msg2 = msg2 + dtNotInserted.Rows.Count.ToString() + " were determined to have errors and were not updated.  " +
                    "Please verify the data is correct and try to update again.  Pressing Yes will bypass the Data checks." +
                    "Do you wish to update the data in its current state?";
            }

            if (dtNotInserted.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show(msg2, "Data Import", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (!bIsUpdate)
                        ValidateData(dtNotInserted, dgvColumns, false, false);
                    else
                        ValidateData(dtNotInserted, dgvColumns, false, true);
                }
                else
                    return dtNotInserted;
            }
            else
                MessageBox.Show(msg2, "Data Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return null;
        }

        public DataSet GetExcelReader(string sFilePath)
        {
            // ExcelDataReader works with the binary Excel file, so it needs a FileStream
            // to get started. This is how we avoid dependencies on ACE or Interop:
            FileStream stream = File.Open(sFilePath, FileMode.Open, FileAccess.Read);

            // We return the interface, so that 
            IExcelDataReader reader = null;
            try
            {
                if (sFilePath.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if (sFilePath.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                reader.IsFirstRowAsColumnNames = true;
                DataSet result = reader.AsDataSet();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SerializeRowToJson(DataRow theRow)
        {
            try
            {
                List<JObject> rowArray = new List<JObject>();
                if (GlobalVariables.CustomColumns == null)
                    GlobalVariables.CustomColumns = GlobalVariables.GlobalConnection.GetColumns();

                    JTokenWriter writer = new JTokenWriter();
                    writer.WriteStartObject();
                    foreach (CustomColumns col in GlobalVariables.CustomColumns)
                    {
                        writer.WritePropertyName(col.ColName.ToUpper());
                        if (theRow.Table.Columns.Contains(col.ColName))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(theRow[col.ColName])))
                                writer.WriteValue(theRow[col.ColName].ToString());
                            else
                                writer.WriteNull();
                        }
                        else
                            writer.WriteNull();
                    }

                    writer.WritePropertyName("EXPERIMENTS_JSONB_ID");
                    writer.WriteValue(theRow["EXPERIMENTS_JSONB_ID"]);

                    writer.WriteEndObject();
                    rowArray.Add((JObject)writer.Token);

                //_daoData.UpdateJson(rowArray);

                return rowArray[0].ToString();
            }
            catch (Exception e)
            {
                return "Could not parse to JSON.";
            }
        }

        public string SerializeTableToJson(DataTable theTable, DataTable theColumns)
        {
            try
            {
                List<JObject> rowArray = new List<JObject>();
                if(GlobalVariables.CustomColumns == null)
                    GlobalVariables.CustomColumns = GlobalVariables.GlobalConnection.GetColumns();

                foreach(DataRow dr in theTable.Rows)
                {
                    string rowValues = "";
                    JTokenWriter writer = new JTokenWriter();
                    writer.WriteStartObject();
                    foreach (CustomColumns col in GlobalVariables.CustomColumns)
                    {
                        writer.WritePropertyName(col.ColName.ToUpper());
                        if (dr.Table.Columns.Contains(col.ColName))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dr[col.ColName])))
                                writer.WriteValue(dr[col.ColName].ToString());
                            else
                                writer.WriteNull();
                        }
                        else
                            writer.WriteNull();
                    }
                    writer.WritePropertyName("EXPERIMENTS_JSONB_ID");
                    writer.WriteNull();
                    writer.WriteEndObject();
                    rowArray.Add((JObject)writer.Token);
                }

                _daoData.InsertJson(rowArray);
                
                return string.Empty;
            }
            catch(Exception e)
            {
                return "Could not parse to JSON.";
            }
        }

        public void SerializeJson(DataRow theData, int nJsonID, string sAction)
        {
            String sJson = SerializeRowToJson(theData);
            if (sAction.Equals("MODIFIED"))
                _daoData.UpdateJson(sJson, nJsonID);
            else if (sAction.Equals("ADDED"))
                _daoData.InsertJson(sJson, nJsonID);
            else
                _daoData.DeleteJson(sJson, nJsonID);
        }

        public DataTable DeSerializeJsonToDataTable()
        {
            string sJson = _daoData.RetrieveJson();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(sJson);
            if (data != null && data.Tables[0] != null)
                return data.Tables[0];
            else
                return null;
        }

        public bool DataLockExists(int ExperimentID, int RowID, string TableName)
        {
            return _daoData.DataLockExists(ExperimentID, RowID, TableName);
        }

        public void CreateDataLock(int ExperimentID, int RowID, string TableName, string LockType)
        {
            _daoData.CreateDataLock(ExperimentID, RowID, TableName, LockType);
        }

        public void DeleteDataLock(int ExperimentID, int RowID, string TableName)
        {
            _daoData.DeleteDataLock(ExperimentID, RowID, TableName);
        }
    }
}
