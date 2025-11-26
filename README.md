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

## 🛠 Setup & Run Instructions

### Open in Visual Studio
1. Clone the repository:  
   ```bash
   git clone https://github.com/yourusername/SensorSim.git
   ```
2. Open `SensorSim.sln` in Visual Studio.
3. Build the solution (`Ctrl+Shift+B`) and run (`F5` or `Ctrl+F5`).

### Run via CLI
```bash
dotnet build
dotnet run --project SensorSim
```

.NET Target:  
This project targets **.NET 9**. Ensure your SDK is up to date.

---

## 🧾 Example JSON Config

**File:** `ConfigJSON/DC-Temp-A.json`

```json
{
  "name": "DC-Temp-A",
  "unit": "DataCentreRoomA",
  "unitType": "°C",
  "minValue": 18,
  "maxValue": 27,
  "sampleRate": 1000
}
```

### Schema Explanation
- `name`: Unique sensor ID  
- `unit`: Physical location  
- `unitType`: Measurement unit (`°C`, `%RH`)  
- `minValue` / `maxValue`: Valid range  
- `sampleRate`: Interval in milliseconds between readings

---

## 📤 Sample Output

**Console Output:**
```
[2025-11-21 14:03:12] DC-Temp-A | DataCentreRoomA | 26.8°C | VALID
[2025-11-21 14:03:13] DC-Temp-A | DataCentreRoomA | 28.5°C | ANOMALY
```

**sensors.txt:**
```
2025-11-21T14:03:12Z,DC-Temp-A,DataCentreRoomA,26.8,°C,VALID
2025-11-21T14:03:13Z,DC-Temp-A,DataCentreRoomA,28.5,°C,ANOMALY
```

---

## 📂 Project Components

### ConfigJSON/
Holds all sensor configuration files in JSON format.

### Domain/
Contains sensor models and validation logic.

### Services/
Implements supporting services for config loading and data persistence.

### Tests/
Unit tests for validation and config loading.

### SensorSim.sln
Visual Studio solution file.

### Program.cs
Main simulation logic.

### sensors.txt
Stores output readings. Located in the project root. Appends new readings; no rotation logic implemented.

### README.md
Project documentation.

---

## 🧪 Build & Test Commands

```bash
dotnet build
dotnet test
```

Tests cover:
- Config parsing
- Validation logic
- Anomaly detection thresholds
- Edge cases (nulls, outliers, repeated values)

---

## 📁 Config File Placement

- Default path: `SensorSim/ConfigJSON/`
- Override via CLI argument:  
  ```bash
  dotnet run --project SensorSim --configPath="path/to/configs"
  ```

---

## 💾 Persistence Details

- **File:** `sensors.txt` in project root  
- **Format:** CSV with timestamp, sensor ID, location, value, unit, and status  
- **Behavior:** Appends new readings; no rotation or archival  
- **Database Support:** Placeholder available in `StorageService.cs` for future DB integration (e.g., SQL connection string via environment variable)

---

## 🐞 Error Handling & Logging

- Logs printed to console with timestamp and severity.
- Verbosity can be adjusted in `Program.cs` (e.g., toggle anomaly-only mode).
- Future enhancement: redirect logs to file or external logging service.

---

## 🔐 Environment Variables & Secrets

If database support is enabled, provide connection string via:

- `appsettings.json`  
- Environment variable:  
  ```bash
  export DB_CONNECTION="your_connection_string"
  ```

---

## 📜 Contribution

- **Contact:** Dion Te Whata — [2110680@studentmail.ucol.ac.nz]  
- Pls Note: In the main branch there is a folder that has updated Final Report there that isn't it i didn't want to risk getting rid of it and losing anything, so the Final Report is the one just above the README file name FinalReport.md



