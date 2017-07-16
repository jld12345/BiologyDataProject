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

using BiologyDepartment.Misc_Files;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using BiologyDepartment.Common;

namespace BiologyDepartment.Data
{
    public class DataUtil
    {
        private DaoData _daoData = new DaoData();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private CommonUtil util = new CommonUtil();

        public DataUtil() { }

        public DataTable GetData()
        {
            List<AnimalData> animalAgg = new List<AnimalData>();
            List<CustomColumns> animalCols = new List<CustomColumns>();
            DataTable dtAnimals = new DataTable();
            string tableFilter = (GlobalVariables.ExperimentData != null) ? GlobalVariables.ExperimentData.TableFilter : string.Empty;
            int tableRow = (GlobalVariables.ExperimentData != null) ? GlobalVariables.ExperimentData.TableRow : 0;
            Stopwatch sw = new Stopwatch();
            Trace.WriteLine("GetData start stopwatch");
            sw.Start();
            GlobalVariables.ExperimentData = null;
            _daoData.BulkExport();
            if (GlobalVariables.ExperimentData == null || GlobalVariables.ExperimentData.JSONTable == null)
            {
                _daoData.GetColumns();
                if (GlobalVariables.CustomColumns == null || GlobalVariables.CustomColumns.Count == 0)
                    return null;
                foreach (CustomColumns c in GlobalVariables.CustomColumns)
                {
                    dtAnimals.Columns.Add(c.ColName, typeof(string));
                }
                foreach (CustomColumns c in GlobalVariables.CustomColumns)
                {
                    if (c.ColDataType.ToUpper().Equals("FORMULA"))
                        dtAnimals.Columns[c.ColName].Expression = c.Formula;
                }
                dtAnimals.Columns.Add("EXPERIMENTS_JSONB_ID", typeof(string));
            }
            else
            {
                dtAnimals = GlobalVariables.ExperimentData.JSONTable.Copy();

                if (GlobalVariables.CustomColumns == null || GlobalVariables.CustomColumns.Count == 0)
                {
                    _daoData.GetColumns();
                    if (GlobalVariables.CustomColumns == null || GlobalVariables.CustomColumns.Count == 0)
                        return null;
                }
                foreach (CustomColumns c in GlobalVariables.CustomColumns)
                {
                    if (c.ColDataType.ToUpper().Equals("FORMULA"))
                    {
                        dtAnimals.Columns[c.ColName].DefaultValue = 0;

                        dtAnimals.Columns[c.ColName].Expression = c.Formula;
                    }
                }
            }
            if (GlobalVariables.ExperimentData != null)
            {
                GlobalVariables.ExperimentData.TableRow = tableRow;
                GlobalVariables.ExperimentData.TableFilter = tableFilter;
            }
            if (dtAnimals == null)
                return null;

            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtAnimals.Columns["EXPERIMENTS_JSONB_ID"];
            dtAnimals.PrimaryKey = keys;
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

        public void ExportToExcel(DataTable DataExport, string sExportType)
        {
            saveFileDialog.Filter = "Excel Worksheets|*.xlsx";
            saveFileDialog.Title = "Export File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                util.CreateExcelExport(saveFileDialog.FileName, DataExport, sExportType);
            }
        }

    }
}
