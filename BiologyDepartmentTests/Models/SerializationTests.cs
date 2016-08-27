using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using BiologyDepartmentModels;
using BiologyDepartmentModels.Utilities;
using System.Diagnostics;

namespace BiologyDepartmentTests.Models
{
    [TestFixture]
    public class SerializationTests
    {
        [Test]
        public void TestSerialization()
        {
            TestModel model = new TestModel();
            string json = Serializer.Serialize(model);
            Assert.True(json == "{\"String\":null,\"Long\":null,\"Int\":null,\"UnsignedInt\":null,\"DateTime\":null}");

            model = new TestModel()
            {
                sString = "xxxxxxxxxxXxxxxxxxxxxxxXxxxxxxxxxxxxxxXxxxxxxxxxxx",
                dtDate = new DateTime(2016, 8, 27, 17, 55, 35, 235),
                nUInt = UInt32.MaxValue,
                nLong = Int64.MinValue,
                nInt = Int32.MinValue
            };

            json = Serializer.Serialize(model);
            Assert.True(json == "{\"String\":\"xxxxxxxxxxXxxxxxxxxxxxxXxxxxxxxxxxxxxxXxxxxxxxxxxx\",\"Long\":-9223372036854775808,\"Int\":-2147483648,\"UnsignedInt\":4294967295,\"DateTime\":\"2016-08-27T17:55:35.235\"}");
        }

        [Test]
        public void TestDeserialization()
        {
            // Let's serialize an empty object
            string json = "{\"String\":null,\"Long\":null,\"Int\":null,\"UnsignedInt\":null,\"DateTime\":null}";

            TestModel model = Serializer.Deserialize<TestModel>(json);
            Assert.True(model.Equals(new TestModel()));
            Assert.False(model.Equals(new TestModel() { sString = "stuff" }));

            model = null;
            Assert.True(Serializer.TryDeserialize(json, out model));
            Assert.True(model.Equals(new TestModel()));

            // Let's deserialize a non-null object.
            model = null;
            json = "{\"String\":\"xxxxxxxxxxXxxxxxxxxxxxxXxxxxxxxxxxxxxxXxxxxxxxxxxx\",\"Long\":-9223372036854775808,\"Int\":-2147483648,\"UnsignedInt\":4294967295,\"DateTime\":\"2016-08-27T17:55:35.235\"}";
            model = Serializer.Deserialize<TestModel>(json);

            TestModel comparisonModel = new TestModel()
            {
                sString = "xxxxxxxxxxXxxxxxxxxxxxxXxxxxxxxxxxxxxxXxxxxxxxxxxx",
                dtDate = new DateTime(2016, 8, 27, 17, 55, 35, 235),
                nUInt = UInt32.MaxValue,
                nLong = Int64.MinValue,
                nInt = Int32.MinValue
            };

            Assert.True(model.sString == comparisonModel.sString &&
                model.dtDate.Value == comparisonModel.dtDate.Value &&
                model.nUInt.Value == comparisonModel.nUInt.Value &&
                model.nLong.Value == comparisonModel.nLong.Value &&
                model.nInt.Value == comparisonModel.nInt.Value);

            Assert.False(model.Equals(new TestModel()));

            model = null;
            Assert.True(Serializer.TryDeserialize(json, out model));
            Assert.True(model.sString == comparisonModel.sString &&
                model.dtDate.Value == comparisonModel.dtDate.Value &&
                model.nUInt.Value == comparisonModel.nUInt.Value &&
                model.nLong.Value == comparisonModel.nLong.Value &&
                model.nInt.Value == comparisonModel.nInt.Value);
        }
    }
}
