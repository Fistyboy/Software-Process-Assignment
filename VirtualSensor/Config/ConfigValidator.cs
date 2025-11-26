using System;
using System.IO;

namespace SensorSim.Config
{ 
    public static class ConfigValidator
    {
        public static void Validate(SensorConfig config)
        {
            if (config == null)
                throw new InvalidDataException("Config object is null.");

            if (string.IsNullOrWhiteSpace(config.Name))
                throw new InvalidDataException("Sensor name is missing in config.");

            if (string.IsNullOrWhiteSpace(config.Unit))
                throw new InvalidDataException("Sensor unit is missing in config.");

            if (config.MinValue >= config.MaxValue)
                throw new InvalidDataException("MinValue must be less than MaxValue.");

            if (config.SampleRate <= 0)
                throw new InvalidDataException("SampleRate must be greater than zero.");
        }
    }
}