# Domain model

A participant (`Active` or `Inactive`) may be assigned a wearable device. A device has connectivity, battery, firmware, and last-seen state. Sessions link one participant and device and progress from `Pending`/`Recording` to `Completed` or `Failed`. Timestamped telemetry belongs to a session and includes signal, quality, and battery.

A session normally requires an existing active participant, their assigned connected device, at least 10% battery, and no active session for that device. Only a recording session can stop. Historical sessions remain associated with participants. IDs 1–12, devices `NP-1001`–`NP-1008`, and initial session IDs 1–20 are deterministic after reset.
