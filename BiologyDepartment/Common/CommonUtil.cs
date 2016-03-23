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
using Excel;
using System.IO;
using BiologyDepartment.Misc_Files;
using System.Diagnostics;

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

            sw.Start();

            if (dgvColumns == null)
                dgvColumns.DataSource = _daoSetup.GetExperimentColumns(GlobalVariables.Experiment.ID);

            foreach (DataGridViewRow dgvr in dgvColumns.Rows)
            {
                if (dgvr.Cells["custom_column_name"].Value == DBNull.Value ||
                    dgvr.Cells["custom_columns_id"].Value == DBNull.Value ||
                    dgvr.Cells["custom_column_data_type"].Value == DBNull.Value ||
                    dgvr.Cells["map_column"].Value == DBNull.Value)
                {
                    string sMsg = "Cannot import data at this time.  Please verify that all columns have been mapped and imported.";
                    MessageBox.Show(sMsg, "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string col = Convert.ToString(dgvr.Cells["custom_column_name"].Value);
                string colId = Convert.ToString(dgvr.Cells["custom_columns_id"].Value);
                string mapCol = Convert.ToString(dgvr.Cells["map_column"].Value);
                if (!string.IsNullOrEmpty(mapCol) && !string.IsNullOrEmpty(col) && !string.IsNullOrEmpty(colId))
                {
                    col = colId + "|" + col + "|" + Convert.ToString(dgvr.Cells["custom_column_data_type"].Value);
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
                    string cellVal = Convert.ToString(dr[entry.Key]);
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
                    _daoData.UpdateExperimentData(animal);
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
    }
}
