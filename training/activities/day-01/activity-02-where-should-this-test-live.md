# Activity 2 — Where Should This Test Live?

**Day:** 1  
**Activity:** 2  
**Related slides:** The Testing Pyramid Is a Conversation; Where Could “Start Recording” Live?  
**Suggested time:** 20 minutes

## Objective

Choose the cheapest test level that can expose a risk faithfully, then explain what confidence and wiring remain uncovered.

## Scenario

NeuroPulse has a React interface, an ASP.NET Core API, PostgreSQL persistence, and a separate device simulator. The team has limited build time and cannot turn every example into a browser journey.

## Your Task

Create a small test-placement matrix for the behaviours below. For each, select a **primary** signal—unit/model, integration, API, contract, or UI—and justify the decision using speed, isolation, fidelity, diagnosis, and maintenance cost.

1. A battery reading of 9% prevents recording.
2. A battery reading of exactly 10% permits recording when every other condition is valid.
3. An inactive participant cannot start a recording.
4. An assigned device and its participant are stored and retrieved together.
5. The API understands the device simulator's status response.
6. A technician can find a participant and initiate the recording journey.
7. Telemetry submitted for a session is persisted and can be retrieved.

Do not aim for one test at every level. Add a second signal only where it addresses a different risk.

## Things to Investigate

- What is the precise risk behind each behaviour?
- Can the proposed level reproduce the relevant condition realistically?
- Does the test need a browser, database, HTTP boundary, or external service shape?
- How quickly would a failure identify the likely cause?
- What wiring remains untested after the primary check passes?
- Which examples deserve deliberate overlap, and which would merely duplicate coverage?

## Evidence

Produce a matrix containing:

| Behaviour/risk | Primary level | Why here? | What remains unproven? | Optional complementary signal |
| --- | --- | --- | --- | --- |

Be ready to defend one choice where your group disagreed.

## Stretch Challenge

Your UI suite now takes 25 minutes and intermittently fails in CI. Choose two checks you would move or replace first. Explain what evidence you would gather before changing the suite.

## Hints

1. “Lowest” is useful only if that level can expose the real failure.
2. A broad journey can show that components are connected but may diagnose a rules failure poorly.
3. A contract check and an end-to-end check answer different questions about an external boundary.

## Discussion

- Which choice gave the fastest diagnostic feedback?
- Where was more than one level justified?
- What assumption most affected your placement decisions?
