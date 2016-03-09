using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADGV;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Specialized;
using System.Collections;
using System.Security.Permissions;
using System.IO;
using System.Linq.Expressions;
using System.Data.Common;
using System.Globalization;
using System.Threading;
using DgvFilterPopup;
using System.Reflection;
using ClosedXML.Excel;
using BiologyDepartment.Misc_Files;
using System.Diagnostics;

namespace BiologyDepartment.Data
{
    public class DataUtil
    {
        private daoData _daoData = new daoData();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        public DataUtil() { }

        public DataTable GetData()
        {
            List<AnimalData> animalAgg = new List<AnimalData>();
            List<CustomColumns> animalCols = new List<CustomColumns>();
            DataTable dtAnimals = new DataTable();

            Stopwatch sw = new Stopwatch();
            Trace.WriteLine("GetData start stopwatch");
            sw.Start();
            animalAgg = _daoData.BulkExport();
            animalCols = _daoData.GetColumns();
            int colPosition = 0;
            foreach (CustomColumns col in animalCols)
            {
                DataColumn newCol = new DataColumn();
                if (!dtAnimals.Columns.Contains(Convert.ToString(col.ColID)))
                {
                    newCol.ColumnName = Convert.ToString(col.ColID);
                    switch (col.ColDataType)
                    {
                        case "INTEGER":
                            newCol.DataType = System.Type.GetType("System.Int32");
                            break;
                        case "DECIMAL":
                            newCol.DataType = System.Type.GetType("System.Decimal");
                            break;
                        case "CHARACTER":
                            newCol.DataType = System.Type.GetType("System.String");
                            break;
                        case "DATE/TIME":
                            newCol.DataType = System.Type.GetType("System.DateTime");
                            break;
                        case "IMAGE":
                            newCol.DataType = System.Type.GetType("System.Byte");
                            break;
                    }
                    newCol.Caption = col.ColName;
                    dtAnimals.Columns.Add(newCol);
                    dtAnimals.Columns[newCol.ColumnName].SetOrdinal(colPosition);
                    colPosition++;
                }
            }
            if (!dtAnimals.Columns.Contains("DataID"))
            {
                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "DataID";
                newCol.DataType = System.Type.GetType("System.Int32");
                newCol.Caption = "Row ID";
                dtAnimals.Columns.Add(newCol);
                dtAnimals.Columns[newCol.ColumnName].SetOrdinal(colPosition);
                colPosition++;
            }

            if (!dtAnimals.Columns.Contains("ExcludeRow"))
            {
                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "ExcludeRow";
                newCol.DataType = System.Type.GetType("System.String");
                newCol.Caption = "Exclude Row";
                dtAnimals.Columns.Add(newCol);
                dtAnimals.Columns[newCol.ColumnName].SetOrdinal(colPosition);
                colPosition++;
            }

            foreach (AnimalData animal in animalAgg)
            {
                DataRow row = dtAnimals.NewRow();
                row["DataID"] = animal.DataID;
                row["ExcludeRow"] = animal.ExcludeRow;

                foreach (KeyValuePair<int, string> entry in animal.AggDictionary)
                {
                    string sType = Convert.ToString(dtAnimals.Columns[Convert.ToString(entry.Key)].DataType);
                    if (string.IsNullOrEmpty(entry.Value))
                        row[Convert.ToString(entry.Key)] = DBNull.Value;
                    else
                    {
                        switch (sType)
                        {
                            case "System.String":
                                row[Convert.ToString(entry.Key)] = Convert.ToString(entry.Value);
                                break;
                            case "System.Int32":
                                row[Convert.ToString(entry.Key)] = Convert.ToInt32(entry.Value);
                                break;
                            case "System.Decimal":
                                row[Convert.ToString(entry.Key)] = Convert.ToDecimal(entry.Value);
                                break;
                            case "System.DateTime":
                                row[Convert.ToString(entry.Key)] = Convert.ToDateTime(entry.Value);
                                break;
                        }
                    }
                }

                dtAnimals.Rows.Add(row);
            }
            dtAnimals.AcceptChanges();
            
            sw.Stop();
            Trace.WriteLine("Elapsed:  " + sw.Elapsed);
            return dtAnimals;
        }

        public void CheckExcludeState(int nRowIndex, bool bIsInitialize, ref AdvancedDataGridView dgExData)
        {
            if (dgExData.Rows[nRowIndex].Cells["ExcludeRow"].Value == DBNull.Value ||
                dgExData.Rows[nRowIndex].Cells["ExcludeRow"].Value == null)
                return;
            if (bIsInitialize)
            {
                if (dgExData.Rows[nRowIndex].Cells["ExcludeRow"].Value.ToString().Equals("N"))
                {
                    dgExData.Rows[nRowIndex].Cells["ExcludeRow"].Value = 'Y';
                    dgExData.Rows[nRowIndex].Cells["EXCLUDE"].Value = true;
                }
                else
                {
                    dgExData.Rows[nRowIndex].Cells["ExcludeRow"].Value = 'N';
                    dgExData.Rows[nRowIndex].Cells["EXCLUDE"].Value = false;
                }
            }
            else
            {
                if (dgExData.Rows[nRowIndex].Cells["ExcludeRow"].Value.ToString().Equals("N"))
                {
                    dgExData.Rows[nRowIndex].Cells["EXCLUDE"].Value = false;
                }
                else
                {
                    dgExData.Rows[nRowIndex].Cells["EXCLUDE"].Value = true;
                }
            }
        }

        public void ExportToExcel(ref AdvancedDataGridView dgExData)
        {
            saveFileDialog.Filter = "Excel Worksheets|*.xlsx";
            saveFileDialog.Title = "Export File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dgExData.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dgExData.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != DBNull.Value && cell.Value != null)
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value;
                        else
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = DBNull.Value;
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Customers");
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                        wb.SaveAs(saveFileDialog.FileName);
                }
            }
        }
    }
}
