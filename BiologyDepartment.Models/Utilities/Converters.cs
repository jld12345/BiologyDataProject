using Newtonsoft.Json.Converters;

namespace PostgresApi.Utilities
{
    internal class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff";
        }
    }
}