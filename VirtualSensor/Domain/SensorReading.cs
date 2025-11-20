namespace SensorSim.Domain
{
    public class SensorReading
    {
        public string SensorId { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsValid { get; set; }
        public bool IsAnomaly { get; set; }
    }
}