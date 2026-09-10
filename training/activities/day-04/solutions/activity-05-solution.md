# Activity 5 — Trainer Solution: Explore an Unreliable NeuroPulse Device

## Example charter

```text
Explore: starting a recording for an otherwise eligible assigned device
With: Unreliable Device plus repetition, time, and recovery
To discover: whether intermittent status failures create misleading state or unsafe repeats
Timebox: 15 minutes of exploration
Evidence: timestamped UI/API/simulator requests, responses, and service-log references
```

Do not use this as a predetermined defect script. Actual intermittent observations
must drive the investigation.

## Example note structure

| Time | Action/state | Observation | Inference/question | Next experiment | Evidence |
| --- | --- | --- | --- | --- | --- |
| 00:00 | Normal; direct NP-1001 status and one eligible start baseline | Record actual status/body/duration and UI result | Comparison only | Restore/reset only if agreed, then apply preset | Network N1, screenshot S1 |
| 02:00 | Unreliable Device; direct provider status repeatedly | Record each `200`/`503` and duration | Failure frequency unknown, not “provider broken” | Correlate one failed call through NeuroPulse | curl log C1 |
| 06:00 | Start once; capture browser and API | Record session status/error and whether navigation/state changed | Does generic UI text hide a provider-specific API result? | Query sessions for side effect, then retry only with state recorded | Network N2, API A1 |
| 10:00 | Repeat after failure/recovery | Record sequence and persisted Recording count | Possible repeated-start risk only if evidence supports it | Compare service log timestamps and provider response | logs L1 |

## Triage model

A defensible report is:

> **Confirmed behaviour:** under Unreliable Device, attempt 3 of 8 direct simulator
> requests returned 503 (record exact run values); the correlated NeuroPulse start
> returned [actual status/body], while the UI displayed [actual text]. Possible impact:
> technicians cannot distinguish temporary dependency failure from eligibility failure.
> Evidence: N2/A1/L1. Frequency is limited to this local timebox; production likelihood
> and desired user wording remain unknown.

Only use the numeric example when that is what was observed. A repeatable automated
candidate is controlled provider-503 handling: assert no session is persisted and the
agreed API failure category is preserved. Random recovery frequency and technician
decision-making are better addressed by further exploration until requirements and
signals are clearer.

## Restoration

Apply Normal, then call:

```bash
curl -i http://localhost:5100/api/devices/NP-1001/status
```

Record `200`, V1 fields (`deviceId`, boolean `connected`, `battery`), prompt response
without induced delay, and no random failure across the verification. A screen label
alone is insufficient restoration evidence.
