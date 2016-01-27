using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment
{
    class AnimalData
    {
        private int ExID = -1;
        DateTime ModDate { get; set; }
        string ModUser { get; set; }
        string ExcludeRow { get; set; }
        private int DataID = -1;
        private int CoreID = -1;
        private int CustomColID = -1;
        private string ColData = "";
        private List<CustomData> AggData = new List<CustomData>();

        public AnimalData()
        {

        }

        public AnimalData(int nExID, int nCoreID, int nDataID)
        {
            ExID = nExID;
            CoreID = nCoreID;
            DataID = nDataID;
        }

        public void SetAggData(string sData)
        {
            string[] sOriginal = sData.Split(';');
            for (int i = 0; i < sOriginal.Length; i++)
            {
                string[] temp = sOriginal[i].Split('|');
                CustomData tempData = new CustomData();
                tempData.AggData = sOriginal[i];
                tempData.DataID = Convert.ToInt32(temp[0]);
                tempData.CoreID = Convert.ToInt32(temp[1]);
                tempData.CustomColID = Convert.ToInt32(temp[2]);
                tempData.ColData = temp[3];
                AggData.Add(tempData);
            }
        }

        public int GetCoreID() { return CoreID; }
        public int GetExID() { return ExID; }
    }


    public class CustomData
    {
        public int CoreID = -1;
        public int DataID = -1;
        public int CustomColID = -1;
        public string ColData = "";
        public string AggData = "";
        
        public CustomData()
        { }
    }
}
