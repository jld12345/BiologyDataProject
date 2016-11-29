﻿using System;
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
using ClosedXML.Utils;
using BiologyDepartment.Misc_Files;
using System.Diagnostics;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

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
            _daoData.BulkExport();
            dtAnimals = GlobalVariables.ExperimentData.JSONTable.Copy();
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

        public void ExportToExcel(AdvancedDataGridView dgExData, bool bIsRExport)
        {
            saveFileDialog.Filter = "Excel Worksheets|*.xlsx";
            saveFileDialog.Title = "Export File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateExcelExport(saveFileDialog.FileName, dgExData);
            }
        }

        private void CreateExcelExport(string sFileName, AdvancedDataGridView dgExData)
        {
            if (dgExData == null)
                return;
            //Create a folder for the export images if they exist
            int nRowCount = 1;
            string sFilePath = new FileInfo(sFileName).Directory.FullName + "\\ExportExcelImages";

            if (Directory.Exists(sFilePath))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(sFilePath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.Delete(sFilePath);
            }

            Directory.CreateDirectory(sFilePath);

            //Creating DataTable
            DataTable dt = new DataTable();
            var temp = (BindingSource)dgExData.DataSource;
            DataView dv = ((DataTable)temp.DataSource).AsDataView();
            dv.RowFilter = temp.Filter;
            dt = dv.ToTable();

            //Change the column name from the number used in the database to the column header name
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ColumnName = dc.Caption;
            }

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Data Picture"] == null)
                    continue;
                byte[] imageBytes = dr["Data Picture"] as byte[];
                MemoryStream mStream = new MemoryStream(imageBytes);
                mStream.Position = 0;

                Image img = Image.FromStream(mStream);
                Bitmap theImage = new Bitmap(img);
                mStream.Close();
                mStream.Dispose();
                string sImagePath = sFilePath + "\\" + nRowCount.ToString() + ".bmp";
                theImage.Save(sImagePath);
                nRowCount++;
            }

            dt.Columns.Remove("Data Picture");
            //Create the excel document
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Data Export");
                if (string.IsNullOrEmpty(sFileName))
                    sFileName = "C:\\tempExcel.xls";
                wb.SaveAs(sFileName);
            }
        }
    }
}
