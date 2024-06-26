﻿using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnooViewer.Common.Converters
{
    public abstract class BaseTimestampConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueString = Encoding.UTF8.GetString(reader.ValueSpan.ToArray());

            if (!string.IsNullOrEmpty(valueString) && valueString != "null" && !bool.TryParse(valueString, out _))
            {
                if (DateTime.TryParse(valueString, out DateTime parsedDate))
                    return parsedDate;

                return ParseDateFromSeconds((long)Convert.ToDouble(valueString));
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (value is DateTime date && date != default)
            {
                writer.WriteRawValue(ConvertToSeconds(date).ToString());
                return;
            }

            writer.WriteNullValue();
        }

        public abstract long ConvertToSeconds(DateTime dateTime);

        public abstract DateTime ParseDateFromSeconds(long seconds);
    }
}
