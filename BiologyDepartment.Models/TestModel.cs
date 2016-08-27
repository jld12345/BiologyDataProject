using BiologyDepartmentModels.Utilities;
using Newtonsoft.Json;
using System;

namespace BiologyDepartmentModels
{
    [JsonObject]
    public class TestModel
    {
        [JsonProperty("String")]
        public string sString { get; set; }

        [JsonProperty("Long")]
        public long? nLong { get; set; }

        [JsonProperty("Int")]
        public int? nInt { get; set; }

        // Apparently Json.Net is unable to handle unsigned longs. Throws errors
        // if you try to deserialize from UInt64.MaxValue
        // [JsonProperty("UnsignedLong")]
        // public ulong? nULong { get; set; }

        [JsonProperty("UnsignedInt")]
        public uint? nUInt { get; set; }

        [JsonProperty("DateTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? dtDate { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is TestModel)
            {
                TestModel model = obj as TestModel;

                //Check all nulls.
                if (this.sString == null && model.sString == null &&
                    this.nLong == null && model.nLong == null &&
                    this.nInt == null && model.nInt == null &&
                    this.nUInt == null && model.nUInt == null &&
                    this.dtDate == null && model.dtDate == null)
                {
                    return true;
                }
            }

            return base.Equals(obj);
        }
    }
}