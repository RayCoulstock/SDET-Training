# Activity 5 — Explore an Unreliable NeuroPulse Device

**Day:** 4  
**Activity:** 5  
**Related slides:** Exploratory Testing Is Structured Engineering; A Useful Charter; Small Heuristic Set  
**Suggested time:** 25 minutes

## Objective

Execute a focused exploratory charter, adapt the investigation from observations, and communicate evidence without confusing inference with fact.

## Before You Start

Make sure NeuroPulse is running and coordinate simulator changes with the class. Open the browser Network tools and start at `http://localhost:3000/training`. Apply **Normal** and record the initial configuration. Do not expose `docs/deliberate-defects.md` as an exercise guide.

## Scenario

Technicians may start recordings while device responses are delayed, intermittent, or not fresh. The known happy-path script provides little evidence about recovery, repeated actions, or the consistency of status shown at different boundaries.

## Your Task

Choose **Unreliable Device** or **Exploratory Testing** and write a charter before testing:

```text
Explore: [a bounded recording or device-status area]
With: [preset plus one or two heuristics]
To discover: [named user or engineering risk]
Timebox: 15 minutes of exploration
Evidence: [timeline and artefacts you will capture]
```

Use only two or three of these heuristics: **boundaries, interruptions, state changes, repetition, invalid sequence, concurrency, time, failure, recovery**. Keep timestamped notes in this form:

| Time | Action / relevant state | Observation | Inference or question | Next experiment | Evidence reference |
|---|---|---|---|---|---|

Spend the first two minutes establishing a comparison under Normal, then apply the chosen preset. Let observations change the next action; do not mechanically enumerate every heuristic. Compare evidence from at least two boundaries, such as the browser UI, browser Network panel, NeuroPulse API, direct simulator status route, or service logs.

Reserve five minutes to triage the strongest finding as **confirmed behaviour**, **possible risk**, **new question**, or **environment/test issue**. State condition, observation, possible impact, reproduction/frequency, evidence, and uncertainty. Identify one finding suitable for a repeatable automated check and one question better served by more exploration.

Finally apply **Normal**, call `GET http://localhost:5100/api/devices/NP-1001/status`, and record evidence that the simulator again returns a V1 response without induced latency or random failure.

## Things to Investigate

- What changes after a failed status request, repeated action, delay, or recovery?
- Do persisted device state, simulator response, and UI presentation agree?
- Which request actually failed, and did the UI preserve useful information?
- What sequence and state would another person need to reproduce the observation?
- Did your next action follow evidence or merely the original plan?

## Evidence

Bring the charter, timestamped notes, evidence from two boundaries, one triaged risk report, an automation candidate, an open question, and proof that **Normal** was restored.

## Stretch Challenge

Pair with another group that chose the other preset. Compare which observations transfer and which depend on configuration, data, or sequence.

## Hints

1. The simulator status route is `GET http://localhost:5100/api/devices/{serialNumber}/status`.
2. Record state and time before interpreting a mismatch.
3. Intermittent results require frequencies and timelines, not “works” or “broken”.

## Discussion

- Which observation changed your investigation?
- What fact did you initially mistake for an inference?
- Which finding deserves automation, and which uncertainty needs another charter?

