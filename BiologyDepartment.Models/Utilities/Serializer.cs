using Newtonsoft.Json;
using System;

namespace PostgresApi.Utilities
{
    /// <summary>
    ///	A serialization class that's meant to abstract the rest of the application
    ///	from how we actually do the serialization and deserialization. If one day we decide
    ///	to switch from JSON.Net to anything else, then we can do that easily if
    ///	everything points to this class.
    /// </summary>
    public static class Serializer
    {
        public static string Serialize<T>(T oSerializable)
        {
            return JsonConvert.SerializeObject(oSerializable);
        }

        public static bool TryDeserialize<T>(string sDeserializable, out T oDeserializedObj)
        {
            try
            {
                oDeserializedObj = Deserialize<T>(sDeserializable);
            }
            catch (Exception ex)
            {
                // If we could not deserialize the object, let's return the default value
                // for whatever we got. Would be 'null' most of the time unless the object
                // is a primitive value.
                oDeserializedObj = default(T);
                return false;
            }

            return true;
        }

        public static T Deserialize<T>(string sDeserializable)
        {
            return JsonConvert.DeserializeObject<T>(sDeserializable);
        }
    }
}