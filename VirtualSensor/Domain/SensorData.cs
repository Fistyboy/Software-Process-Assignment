namespace SensorSim.Domain
{
    public class SensorData
    {
        public int ReadingId { get; set; }
        public string SensorName { get; set; }
        public string Location { get; set; }
        public double ValueC { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsValid { get; set; }
        public bool IsAnomaly { get; set; }
    }
}