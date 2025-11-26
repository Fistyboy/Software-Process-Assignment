# Final Reflection Report

## Introduction  
At the beginning of this course, I aimed to improve my technical skills and confidence in programming. I was particularly interested in understanding how professional developers manage code, collaborate, and maintain version control. My goal was to build a defensible, well-structured project using GitHub and Visual Studio.  

Since I am very new to GitHub, I haven’t always been confident that I’ve done everything I was meant to, and definitely not in the exact order. This made the learning curve steeper, but it also gave me valuable experience in troubleshooting and adapting when things didn’t go as planned.

---

## LinkedIn Learning Coursework  
I completed LinkedIn Learning modules on Git and GitHub, which helped me understand branching, commits, pull requests, and tagging. I also explored Visual Studio integration with Azure DevOps, which clarified how teams manage repositories and enforce workflows. These courses gave me a strong foundation in collaborative development and version control.

---

## Testing Practices  
Throughout the project, I applied unit testing to validate sensor configuration logic and reading ranges. Integration testing ensured that sensor simulation and logging worked together correctly. System testing confirmed that the full pipeline — from config loading to reading storage — behaved as expected. This reinforced the importance of testing in maintaining software reliability.

---

## Configuration Management  
I learned to manage changes using Git branches and tags. Each feature was developed in its own branch (e.g., `feature/init`, `feature/log-store`) and merged into `develop` via pull requests. I used conventional commit messages (`feat:`, `fix:`, `test:`) and tagged the final milestone as `v1.0`. This structure made the project audit-ready and easy to track.

---

## Git Usage  
- **Branching Strategy**:  
  Used `main` (protected), `develop`, and multiple `feature/` branches for modular development.  
- **Feature Branches**:  
  - `feature/init`: Sensor initialization logic  
  - `feature/simulate`: Temperature and humidity simulation  
  - `feature/log-store`: Logging and storing sensor readings  
  - `feature/validate`: Validation of sensor data structure  
  - `feature/tests`: Unit tests for sensor initialization  
- **Pull Requests**:  
  Each feature branch was merged into `develop` via pull requests. Descriptions included summaries, reasons, and file changes.  
- **Tagging**:  
  Tag `v1.0` was created and pushed to `main`. A GitHub release was published to mark the milestone.  

Because I am new to GitHub, I often felt unsure whether I was following the exact workflow correctly. Sometimes I completed steps out of order, but I learned that Git allows recovery and correction, and documenting these steps helped me stay accountable.

---

## Feature Development  
Each feature was isolated in its own branch and committed with meaningful messages:
- `feature/init`: Added config validation logic in `SensorSim/Config/ConfigValidator.cs`
- `feature/simulate`: Simulated readings in `SensorSim/Program.cs`
- `feature/log-store`: Implemented logging in `SensorSim/Services/StorageServices.cs`
- `feature/validate`: Defined validation rules in `SensorSim/Domain/SensorReading.cs`
- `feature/tests`: Created unit tests in `Tests/VirtualSensorTests.cs`

---

## Challenges  
- Merge conflict between `feature/log-store` and `develop` due to overlapping edits  
- JSON config validation failed when `unitType` was missing  
- GitHub README didn’t render correctly due to duplicate files  
- Time management during testing and branching setup was critical  

---

## Milestone Tag  
- Tag `v1.0` was created on `main` using:
  ```bash
  git checkout main
  git pull origin main
  git tag v1.0
  git push origin v1.0
  ```
- A GitHub release was published with the title `v1.0` and a summary of core features  
- This marks the completion of the project and aligns with the assessment brief

---

## Critical Insight  
The most challenging aspect was managing time across branching, testing, and documentation. I learned that structured planning and collaboration are essential. Using GitHub’s pull request workflow helped me stay organized and produce a defensible, transparent codebase.  

As someone new to GitHub, I wasn’t always confident I was doing things in the right order, but this uncertainty forced me to slow down, document carefully, and learn by correcting mistakes. That process gave me a deeper understanding of version control and confidence that I can now apply in future projects.

---

## Conclusion  
This project helped me integrate technical skills with professional workflows. I now understand how to build audit-ready software using Git, GitHub, and Visual Studio. The LinkedIn Learning modules and hands-on development gave me confidence in version control, testing, and configuration management. Even though I was new to GitHub and sometimes unsure of the order of steps, I learned that persistence and documentation can overcome those gaps. I’m proud of the structure and clarity of my final submission.

---


