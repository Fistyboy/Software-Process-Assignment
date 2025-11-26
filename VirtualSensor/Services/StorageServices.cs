using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SensorSim.Domain;   // for SensorReading

namespace SensorSim.Services
{
    public class StorageService
    {
        private readonly string _connectionString;

        public StorageService(string databasePath = "sensors.db")
        {
            _connectionString = $"Data Source={databasePath}";
            InitialiseDatabase();
        }

        // Create table if it doesn't exist
        private void InitialiseDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
            @"CREATE TABLE IF NOT EXISTS SensorReadings (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Timestamp TEXT NOT NULL,
                SensorId TEXT NOT NULL,
                Location TEXT NOT NULL,
                Value REAL NOT NULL,
                IsValid INTEGER NOT NULL,
                IsAnomaly INTEGER NOT NULL
            );";
            tableCmd.ExecuteNonQuery();
        }

        // Store a single SensorReading
        public void Store(SensorReading reading)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var insertCmd = connection.CreateCommand();
            insertCmd.CommandText =
            @"INSERT INTO SensorReadings (Timestamp, SensorId, Location, Value, IsValid, IsAnomaly)
              VALUES ($timestamp, $sensorId, $location, $value, $isValid, $isAnomaly);";

            insertCmd.Parameters.AddWithValue("$timestamp", reading.Timestamp.ToString("o"));
            insertCmd.Parameters.AddWithValue("$sensorId", reading.SensorId);
            insertCmd.Parameters.AddWithValue("$location", reading.Location);
            insertCmd.Parameters.AddWithValue("$value", reading.Value);
            insertCmd.Parameters.AddWithValue("$isValid", reading.IsValid ? 1 : 0);
            insertCmd.Parameters.AddWithValue("$isAnomaly", reading.IsAnomaly ? 1 : 0);

            insertCmd.ExecuteNonQuery();
        }

        // Retrieve recent readings
        public List<SensorReading> GetRecentValues(int count)
        {
            var results = new List<SensorReading>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText =
            @"SELECT Timestamp, SensorId, Location, Value, IsValid, IsAnomaly
              FROM SensorReadings
              ORDER BY Id DESC
              LIMIT $count;";

            selectCmd.Parameters.AddWithValue("$count", count);

            using var reader = selectCmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(new SensorReading
                {
                    Timestamp = DateTime.Parse(reader.GetString(0)),
                    SensorId = reader.GetString(1),
                    Location = reader.GetString(2),
                    Value = reader.GetDouble(3),
                    IsValid = reader.GetInt32(4) == 1,
                    IsAnomaly = reader.GetInt32(5) == 1
                });
            }

            return results;
        }
    }
}//This is for staging a commit