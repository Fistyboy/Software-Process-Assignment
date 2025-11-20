using SensorSim.Domain;
using SensorSim.Config;

namespace SensorSim.Services
{
    public static class SensorValidator
    {
        public static bool IsValid(SensorReading reading, SensorConfig config)
        {
            return reading.Value >= config.MinValue && reading.Value <= config.MaxValue;
        }

        public static bool IsAnomalous(SensorReading reading, SensorConfig config)
        {
            double range = config.MaxValue - config.MinValue;
            double margin = range * 0.2;
            return reading.Value < config.MinValue - margin || reading.Value > config.MaxValue + margin;
        }
    }
}