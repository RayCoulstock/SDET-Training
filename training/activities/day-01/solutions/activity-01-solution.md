# Activity 1 — Trainer Solution: Quality Across the SDLC

## Example lifecycle map

| Stage | Intervention and question answered | Kind | Participants | Feedback or artefact |
| --- | --- | --- | --- | --- |
| Idea/refinement | Turn each start rule into concrete examples, including 9%, 10%, and 11% battery. Clarify whether “connected” means stored status, live simulator status, or both. | Prevention | Product owner, technician/domain expert, developer, SDET | Agreed examples and acceptance criteria |
| Design | Review the API–simulator boundary, failure modes, timeouts, ownership of validation, and concurrent start requests. | Prevention | Developer, SDET, architect/operations | Sequence diagram, contract, risk list, observability requirements |
| Implementation | Exercise the decision logic with fast boundary and negative tests; review that every rejection has a stable, useful reason. | Detection | Developer and reviewer, with SDET input | Unit/service results and review comments |
| Integration/build | Test persistence and the real database, API request/response behaviour, and the simulator V1 contract. Run focused checks on every change. | Detection | Developers, SDET, CI owner | CI results, contract report, logs and failing examples |
| Pre-release | Run a small UI journey for a valid participant/device and selected rejection paths in a production-like environment. | Detection | SDET, developer, product owner/technician | Release evidence, screenshots/traces, exploratory notes |
| Deployment | Release progressively; perform a post-deploy smoke check and watch rejection/error rates before widening exposure. | Detection/diagnosis | Operations, developer, SDET | Deployment decision, health and smoke results |
| Operation | Correlate a start attempt across UI, API, database, and simulator using an attempt/correlation ID; dashboard rejection reasons and latency. | Diagnosis | Operations/support and development team | Searchable structured events, metrics, alert and support runbook |

## Important points to surface

- **Exactly 10% belongs early and low.** It makes the inclusive boundary unambiguous
  before implementation and gives a fast service-level regression check. One focused
  integrated check can then confirm that the live simulator and database wiring do
  not alter the decision.
- **There are two notions of connected.** The stored device record and simulator's
  live response could disagree. The team must define which is authoritative and how
  stale/unavailable status is reported.
- **Concurrency remains a risk.** Two simultaneous requests could both observe “no
  active recording.” A database constraint, transaction, or concurrency test may be
  needed; a happy-path browser test does not establish atomicity.
- **The fastest feedback** is an example review before code, followed by a focused
  rule test. **The most realistic confidence** comes from a thin integrated/UI check,
  but it is slower and diagnoses a failure less precisely.
- A useful post-release residual risk is simulator/network degradation or races under
  real traffic. Monitoring rejection reason, dependency latency, and duplicate active
  sessions provides evidence unavailable before release.

## Stretch change: “more than 10%”

Mark work at acceptance examples, domain terminology, rule implementation, boundary
tests (9/10/11), API/error documentation, UI messaging, contract or fixture data,
release notes, operational dashboards, and support documentation. Existing historical
events may also need a versioned rule so that operators can explain decisions made
before and after the change.

## Debrief prompts

Ask groups which intervention would have prevented an incorrect `> 10` implementation,
which would reveal a mismatch between stored and live connection state, and who owns
the resulting action. The SDET contributes boundary analysis, test design, tooling,
and diagnosability—not sole ownership of quality.
