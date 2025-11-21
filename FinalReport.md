Final Reflection Report
====
This reflection is written for my Software Process class, where I was tasked with completing an individual project assignment that combined technical development with project management practices. My name is Dion Te Whata, a 41‑year‑old student who has come to programming later in life. Balancing this project alongside three exams was stressful, and the time pressure added to my anxiety. Despite these obstacles, I was able to complete the assignment in a single 12‑hour day, which surprised me and gave me confidence in my ability to manage intense workloads. This report outlines how I approached the technical requirements, integrated project management principles, and reflected on my learning outcomes.

### LinkedIn Learning Coursework ###

A significant part of the assignment involved completing the LinkedIn Learning courses Learning Git and GitHub and C# Unit Testing with xUnit. These courses were time‑consuming and contributed to my anxiety, but they provided essential knowledge that directly supported the project. To stay organized, I tracked each course in my GitHub Kanban board. Each issue represented a course topic, and I broke down the smaller videos into individual checkboxes. This gave me a sense of progress as I ticked off each video, even when the workload felt heavy. The courses helped me refresh fundamentals I had not touched since earlier programming classes, and they gave me practical skills in Git workflows and unit testing.

### Feature Development ### 
The sensor simulation was built by dividing the problem into modules: configuration, data generation, validation, logging, and anomaly detection. Initialization loaded sensor metadata from a configuration file, with fail‑fast validation to stop errors early. Data simulation introduced variability to mimic real‑world conditions, while validation checked ranges and flagged anomalies. Logging captured both normal and fault conditions, and anomaly detection used a moving average to identify spikes or sensor failures. Structuring the work into components gave me a roadmap to follow and kept the 12‑hour sprint manageable.

### Testing Practices ### 
Using xUnit, I created unit tests around the most fragile parts: configuration parsing, validation rules, and anomaly detection. Edge cases included null values, extreme outliers, and repeated identical readings to simulate sensor faults. By seeding random generators, I kept tests deterministic and reliable. Running these tests during the build gave me confidence that rapid changes did not silently break functionality. This reflected project management principles of quality assurance under time pressure — testing became my safeguard against rushing mistakes in a compressed schedule.

### Documentation ### 
I produced a README with setup instructions, architecture overview, and function descriptions. Configuration keys were documented with examples, and I included notes on running the test suite and interpreting results. This documentation ensured that even though the project was completed quickly, the outcome was transparent and reproducible. In project management terms, this satisfied communication management, showing that clear documentation can substitute for extended stakeholder meetings when time is limited.

### Learning Outcomes ### 
From the ICT perspective, I strengthened my technical skills in .NET development, Git workflows, and unit testing. From the Software Process and Project Management course, I applied principles such as:

- Time management: Completing the project in one 12‑hour session required strict focus and prioritization.

- Progress tracking: GitHub’s burndown chart and Kanban board gave me real‑time visibility of progress,       mirroring agile tracking tools.

- Risk management: Identifying potential failure points (config errors, anomalies) and mitigating them        through validation and testing reduced the chance of late‑stage breakdowns.
  
- Quality management: Frequent commits, automated tests, and structured documentation ensured quality         despite the compressed timeline.

- Stakeholder communication: Using GitHub commits, Kanban boards, and burndown tracking provided evidence     of progress without needing extended reporting cycles.

- This showed me that even in a single‑day sprint, project management tools and principles can guide          technical work and keep it defensible.

### Critical Insight ### 
The hardest part was sustaining focus and managing stress during a 12‑hour build, especially after the time‑consuming LinkedIn Learning courses. Breaking the work into modules and watching the GitHub burndown chart drop gave me motivation and structure. The Kanban board also helped me visualize progress across both the coursework and the coding. Technically, anomaly detection was challenging, but treating it as a risk management exercise helped me design thresholds and fault flags systematically. Testing exposed hidden assumptions, reinforcing the lesson that quality must be built in, even under time pressure. Next time, I would prepare more upfront (config templates, test scaffolding) to reduce setup time, and integrate continuous integration earlier to automate quality checks. This would make the sprint smoother and strengthen both my technical workflow and my ability to manage projects under intense deadlines.

### Conclusion ### 
Completing this Software Process project was both stressful and rewarding. The LinkedIn Learning courses consumed time and added to my anxiety, but they provided essential skills that supported the assignment. The one‑day sprint tested my focus and resilience, and GitHub’s burndown chart and Kanban board gave me structure and visibility. By combining technical development with project management principles, I delivered a working application, documented it clearly, and reflected critically on my process. This experience has shown me that even under pressure, structured planning, quality assurance, and transparent communication can lead to successful outcomes.
