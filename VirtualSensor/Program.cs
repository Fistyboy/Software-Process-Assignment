using System;
using System.IO;
using System.Threading;
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
            // 🔹 Load multiple configs
            var configs = new[]
            {
                ConfigLoader.Load("ConfigJSON/TemperatureSensor.json"),
                ConfigLoader.Load("ConfigJSON/HumiditySensor.json")
            };

            var storage = new StorageService();

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

                    Console.WriteLine($"[{reading.Timestamp:O}] {reading.SensorId} @ {reading.Location} = {reading.Value:N1}");

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

        private static double GenerateSensorValue(double min, double max)
        {
            return min + Random.NextDouble() * (max - min);
        }
    }
}