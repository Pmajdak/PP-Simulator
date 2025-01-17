using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Simulator;

public class PointConverter : JsonConverter<Point>
{
    public override Point Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var parts = reader.GetString()?.Split(',');
        if (parts == null || parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
        {
            throw new JsonException($"Invalid Point format: {reader.GetString()}");
        }
        return new Point(x, y);
    }

    public override void Write(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }

    public override Point ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Read(ref reader, typeToConvert, options);
    }

    public override void WriteAsPropertyName(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
    {
        writer.WritePropertyName(value.ToString());
    }
}