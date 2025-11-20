# SensorSim

This project simulates environmental sensors for temperature and humidity across multiple data center rooms. It was developed to meet the requirements of the PM600 brief, including core functionality and optional enhancements.

---

## 📌 Core Requirements

- **Sensor Simulation**  
  Generates readings for temperature and humidity sensors with configurable ranges and sample rates.

- **Configuration Management**  
  Loads sensor settings from JSON files (`ConfigJSON/`) using a structured `SensorConfig` model.

- **Validation**  
  Each reading is checked against defined min/max values to determine validity.

- **Anomaly Detection**  
  Readings outside expected thresholds are flagged as anomalies.

- **Persistence**  
  Results are stored via `StorageService` into `sensors.txt` or database for audit tracking.

---

## 🌟 Optional Enhancements Implemented

- **Dynamic Config Loading**  
  Automatically loads all `.json` files from the `ConfigJSON` folder, eliminating hardcoding.

- **Multi-Sensor Support**  
  Supports multiple sensors (e.g., `DC-Temp-A`, `DC-Humidity-B`) running in sequence.

- **Multi-Location Support**  
  Sensors can be assigned to different rooms (`DataCentreRoomA`, `DataCentreRoomB`).

- **Unit Display**  
  Added `unitType` property (e.g., `°C`, `%RH`) to JSON configs and `SensorConfig.cs`, displayed in console output.

- **Audit-Ready Output**  
  Console logs include timestamps, sensor IDs, locations, values, and flags for invalid or anomalous readings.

---

## 📂 Project Components

### ConfigJSON/
Holds all sensor configuration files in JSON format.  
Each file defines:
- `name` — Sensor identifier (e.g., DC-Temp-A)
- `unit` — Location (e.g., DataCentreRoomA)
- `unitType` — Measurement unit (°C, %RH)
- `minValue` / `maxValue` — Valid range
- `sampleRate` — Sampling interval in ms

---

### Domain/
Contains sensor models and validation logic.  
Key files:
- `SensorConfig.cs` — Maps JSON properties to C# objects
- `SensorReading.cs` — Represents a single sensor reading
- `SensorValidator.cs` — Validates readings and detects anomalies

---

### Services/
Implements supporting services for the simulation.  
- `ConfigLoader.cs` — Loads JSON configs into `SensorConfig`
- `StorageService.cs` — Persists readings to `sensors.txt` or database

---

### Tests/
Unit tests for validation and config loading.  
Ensures:
- Configs are parsed correctly
- Invalid/malformed configs are caught
- Readings outside thresholds are flagged

---

### SensorSim.sln
The Visual Studio solution file.  
Open this to build and run the project.

---

### Program.cs
Main simulation logic.  
- Loads configs from `ConfigJSON/`
- Generates random sensor values within defined ranges
- Validates and flags anomalies
- Outputs results to console and storage

---

### sensors.txt
Output file containing recorded readings.  
Includes:
- Timestamp
- Sensor ID
- Location
- Value + UnitType
- Flags for invalid or anomalous readings

---

### README.md
Project documentation.  
Explains:
- Purpose
- Features
- Setup instructions
- Sample output
- Future improvements

---

