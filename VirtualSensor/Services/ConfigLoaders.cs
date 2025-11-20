using System;
using System.IO;
using System.Text.Json;

namespace SensorSim.Config
{
    public static class ConfigLoader
    {
        public static SensorConfig Load(string path)
        {
            // 🔍 Step 1: Read raw JSON from file
            string json = File.ReadAllText(path);

            // ✅ Debug: print raw JSON contents
            Console.WriteLine("Raw JSON string:");
            Console.WriteLine(json);

            // 🔍 Step 2: Deserialize into SensorConfig
            var config = JsonSerializer.Deserialize<SensorConfig>(json);

            // ✅ Debug: print deserialized values
            Console.WriteLine($"DEBUG: Name={config?.Name}, Unit={config?.Unit}, Min={config?.MinValue}, Max={config?.MaxValue}, Rate={config?.SampleRate}");

            return config ?? throw new InvalidDataException("Failed to deserialize SensorConfig.");
        }
    }
}