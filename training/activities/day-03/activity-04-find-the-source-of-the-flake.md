# Activity 4 — Find the Source of the Flake

**Day:** 3  
**Activity:** 4  
**Related slides:** Flakiness Is a Symptom; Asynchronous Failure: Ask What Completed  
**Suggested time:** 15 minutes

## Objective

Classify an intermittent failure, gather evidence that distinguishes causes, and propose a cause-focused response.

## Before You Start

Make sure NeuroPulse is running. Coordinate with the trainer before changing `/training`; return it to **Normal** when finished.

## Your Task

Choose one investigation:

- review the fixed wait in `tests/playwright/tests/navigation.spec.ts` without changing simulator state; or
- apply **Unreliable Device** and exercise Start Recording for an eligible participant while capturing browser network evidence.

Write at least three plausible hypotheses across the categories **timing**, **state/data**, **environment/dependency**, and **concurrency**. Rank them before changing code or timeouts.

Run a small, recorded reproduction attempt. For each observation, note which hypothesis it supports or weakens. Use an assertion message, trace, screenshot, Network entry, API/simulator log, or repeated result as evidence. Do not “fix” the test by adding a delay, increasing a timeout, or relying on retries.

Conclude with the next discriminating experiment and a proportionate cause-focused change. Mark uncertainty explicitly if the evidence is not decisive.

## Things to Investigate

- Which operation actually needs to complete?
- Did the request leave the browser and reach each dependency?
- Could another test or learner mutate the same state?
- Does a retry provide diagnostic information or hide instability?
- Is the failure expected behaviour under the selected scenario?

## Evidence

Show the ranked hypotheses, reproduction record, at least two evidence sources, and the next diagnostic action or proposed fix.

## Stretch Challenge

Design a condition-based assertion or observation that would distinguish slow success from provider failure.

## Hints

1. Establish whether the failure is reproducible before editing.
2. A trace timeline and service log answer different questions.
3. Return scenario controls to Normal even if the investigation is incomplete.

## Discussion

- Which evidence changed your ranking?
- Why would a larger timeout be an unsafe first response?
- What would make your proposed fix demonstrably effective?
