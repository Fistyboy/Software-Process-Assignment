// csharp
using System.Text.Json.Serialization;

public class SensorConfig
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;

    [JsonPropertyName("unitType")]
    public string UnitType { get; set; } = string.Empty;

    [JsonPropertyName("minValue")]
    public double MinValue { get; set; }

    [JsonPropertyName("maxValue")]
    public double MaxValue { get; set; }

    [JsonPropertyName("sampleRate")]
    public int SampleRate { get; set; }
}