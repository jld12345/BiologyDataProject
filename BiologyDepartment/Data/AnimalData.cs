using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment
{
    public class AnimalData
    {
        public int DataID { get; set;}
        public int ExID { get; set; }
        public DateTime ModDate { get; set; }
        public string ModUser { get; set; }
        public DateTime DelDate { get; set; }
        public string DelUser { get; set; }
        public string ExcludeRow { get; set; }
        public string DataAgg { get; set; }
        public byte[] Picture { get; set; }

        public Dictionary<int, string> AggDictionary { get; set; }

        private string[] sColSeperator = new string[] { "|^|" };
        private string[] sDataSeperator = new string[] { "^*^" };

        public AnimalData()
        {

        }

        public void GetAggData()
        {
            AggDictionary = new Dictionary<int,string>();
            string[] sColumns = DataAgg.Split(sColSeperator, StringSplitOptions.None);
            for (int i = 0; i < sColumns.Length; i++)
            {
                string[] temp = sColumns[i].Split(sDataSeperator, StringSplitOptions.None);
                if(temp.Length > 1)
                    AggDictionary.Add(Convert.ToInt32(temp[0]), temp[1]);
            }
        }

        public void SetAggData()
        {
            string sNewAgg = "";
            foreach(KeyValuePair<int, string> entry in AggDictionary)
            {
                sNewAgg = sNewAgg + sColSeperator + entry.Key + sDataSeperator + entry.Value;
            }
            var trimChars = "|^|";
            DataAgg = sNewAgg.TrimStart(trimChars.ToArray());
        }

    }

    public class CustomColumns
    {
        public int ColID { get; set; }
        public string ColName { get; set; }
        public string ColDataType { get; set; }
        public int EX_ID { get; set; }

        public CustomColumns() { }
    }

}
