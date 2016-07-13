using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using System.Xml;
using System.IO;


namespace RClass
{
    public class RClassUtil
    {
        private RClassDao daoData = new RClassDao();
        public string ADUserName { get; set; }
        public string ADPass { get; set; }
        public string DBUser { get; set; }
        public string DBPass { get; set; }
        public string ADUserGroup { get; set; }
        private DataSet ds = new DataSet();

        public RClassUtil() { }

        public void SetDao()
        {
            daoData.SetUserPass(DBUser, DBPass);
        }

        public DataTable GetExperiments(string sUserName)
        {
            ds = daoData.getExperiments(sUserName);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public XmlDocument GetXMLDoc(DataTable theData) 
        {
            if (theData == null || theData.Rows.Count == 0)
                return null;

            string filename = "XmlDoc.xml";
            if (File.Exists(filename))
                File.Delete(filename);

            // Create the FileStream to write with.
            System.IO.FileStream stream = new System.IO.FileStream
                (filename, System.IO.FileMode.Create);
            theData.WriteXml(stream);
            stream.Close();

            XmlDocument doc = new XmlDocument();
            doc.Load("XmlDoc.xml");
            File.Delete(filename);
            return doc;
        }

        public int RowCount(DataTable dt)
        {
            return dt.Rows.Count;
        }

        public DataTable GetData(int exID, string sFilter = "")
        {
            List<AnimalData> animalAgg = new List<AnimalData>();
            List<CustomColumns> animalCols = new List<CustomColumns>();

            DataTable dtAnimals = new DataTable();

            animalAgg = daoData.BulkExportData(exID);
            animalCols = daoData.GetColumns(exID);
            int colPosition = 0;
            foreach (CustomColumns col in animalCols)
            {
                DataColumn newCol = new DataColumn();
                if (!dtAnimals.Columns.Contains(col.ColName))
                {
                    newCol.ColumnName = col.ColName;
                    newCol.Caption = col.ColID.ToString();
                    newCol.DataType = System.Type.GetType("System.String");
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
                    foreach (DataColumn dc in dtAnimals.Columns)
                    {
                        if (string.IsNullOrEmpty(dc.Caption) || !dc.Caption.Equals(entry.Key.ToString()))
                            continue;

                        if (string.IsNullOrEmpty(entry.Value))
                            row[dc.ColumnName] = " ";
                        else
                        {
                            row[dc.ColumnName] = entry.Value;
                        }
                    }
                }

                dtAnimals.Rows.Add(row);
            }

            dtAnimals.AcceptChanges();

            DataTable dt = new DataTable();
            DataView dv = dtAnimals.AsDataView();
            if (!string.IsNullOrEmpty(sFilter))
                dv.RowFilter = sFilter;
            dt = dv.ToTable();

            dt.AcceptChanges();
            dt.TableName = "ExData";
            return dt;
        }
    }
}
