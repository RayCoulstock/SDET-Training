# Activity 7 — Trainer Solution: Phase 1 Assessment Preparation

## Example bounded risk

An inactive participant must not acquire a new recording session, regardless of whether
the request comes from the browser or directly through the API.

| Capability | Decision to defend | Useful evidence | What would not be enough |
| --- | --- | --- | --- |
| Test strategy and placement | Put rule combinations below the UI and retain one user-facing rejection journey | Risk statement, placement rationale, and explicit gaps | A test pyramid diagram or test count alone |
| Focused Playwright coverage | Browser check proves accessible action/feedback without duplicating all rule cases | Semantic locator, controlled precondition, web-first outcome, clean run and failure trace | A fixed wait followed by any `.badge` |
| API investigation and negative testing | Direct client cannot bypass inactivity rule | Request/response, persisted-state comparison, and requirement reference | `400` alone without checking side effects |
| Risk communication | State a bounded condition, evidence, impact, and uncertainty | Concise finding plus reproducible sequence and next decision | “Recording is broken” |
| Transparent, appropriate AI use | AI may broaden ideas, not determine truth | Sanitised prompt/output, claim classification, primary-source verification, disclosed retained contribution | “AI generated the tests” |

## Collection order

1. Confirm the story and identify which seeded or synthetic state is safe to use.
2. Establish a successful baseline and inspect the API representation.
3. Execute the focused API negative check and verify no new session was persisted.
4. Add the distinct browser evidence, preserving trace/screenshot on failure.
5. Summarise the risk, scope, limitations, and any verified AI contribution; obtain
   human review before relying on it.

The setup assumption is that no parallel learner resets or changes the selected state.
Preserve exact request/response, time, scenario, identifiers, and Playwright trace.
Human review is essential when deciding whether observed status/error behaviour meets
the requirement and whether the evidence is sufficient.

Passing output demonstrates execution, not judgement. The strongest artefact is often
the map connecting risk, chosen boundary, observation, and admitted limitation; a full
screen recording can be removed if the network record and trace already answer the
decision.
