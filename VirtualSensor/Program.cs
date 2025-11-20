using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using SensorSim.Config;
using SensorSim.Domain;
using SensorSim.Services;

namespace SensorSim
{
    internal class Program
    {
        private static readonly Random Random = new();

        static void Main(string[] args)
        {
            // 🔹 Step 1: Load all JSON config files dynamically from ConfigJSON folder
            string configFolder = "ConfigJSON";
            var configFiles = Directory.GetFiles(configFolder, "*.json");

            var configs = new List<SensorConfig>();
            foreach (var path in configFiles)
            {
                Console.WriteLine($"Loading config: {Path.GetFileName(path)}");
                var config = ConfigLoader.Load(path);
                ConfigValidator.Validate(config);
                configs.Add(config);
            }

            var storage = new StorageService();

            // 🔹 Step 2: Loop through each sensor config and simulate readings
            foreach (var config in configs)
            {
                Console.WriteLine($"Sensor simulation started for sensor: {config.Name}");

                int count = 0;
                while (count < 10) // run 10 readings per sensor
                {
                    double value = GenerateSensorValue(config.MinValue, config.MaxValue);

                    var reading = new SensorReading
                    {
                        SensorId = config.Name,
                        Location = config.Unit,
                        Value = value,
                        Timestamp = DateTime.Now
                    };

                    reading.IsValid = SensorValidator.IsValid(reading, config);
                    reading.IsAnomaly = SensorValidator.IsAnomalous(reading, config);

                    storage.Store(reading);

                    Console.WriteLine($"[{reading.Timestamp:O}] {reading.SensorId} @ {reading.Location} = {reading.Value:N1}{config.UnitType}");

                    if (!reading.IsValid)
                        Console.WriteLine("⚠️ Invalid reading!");

                    if (reading.IsAnomaly)
                        Console.WriteLine("🚨 Anomaly detected!");

                    Thread.Sleep(config.SampleRate);
                    count++;
                }

                Console.WriteLine($"{config.Name}: Simulation complete. Check sensors.db for results.");
            }
        }

        // 🔹 Step 3: Random value generator for sensor readings
        private static double GenerateSensorValue(double min, double max)
        {
            return min + Random.NextDouble() * (max - min);
        }
    }
}