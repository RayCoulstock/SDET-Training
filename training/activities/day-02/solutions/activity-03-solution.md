# Activity 3 — Trainer Solution: Break the API

## Example charter

> Explore start-session eligibility around the battery threshold and invalid state,
> using direct API requests, to discover whether the service preserves the recording
> invariant and returns actionable rejection evidence.

Start from a known successful assigned participant/device under Normal. Because the
API does not expose an update route for battery, the 9% seeded assigned device
(`NP-1004`) is the practical below-boundary observation; an exact 10% case needs
controlled setup below the public API or an agreed temporary fixture. Do not claim an
untested boundary result.

## Example result table

| Variation | Why it matters | Expected outcome | Evidence to capture | Conclusion |
| --- | --- | --- | --- | --- |
| Valid active participant with assigned, connected device above 10% | Establish baseline | `201`, Recording session returned and persisted | Status, `Location`, body, subsequent session lookup | Baseline only passes if no recording is already active. |
| Assigned device at 9% | Just below inclusive threshold | `400`; no session; error says battery must be at least 10% | Response and before/after session list | Firmly supported by the story. |
| Exactly 10% with every other condition valid | Inclusive boundary | `201` | Controlled fixture plus returned/persisted session | Requirement says “at least”; do not substitute 9%/11% for this check. |
| Device ID not assigned to the participant | Business identity/state | `400`; no state change | Error and session lookup | Assignment invariant is enforced by the service. |
| Repeat the same valid start while first is active | Idempotency/concurrency risk | No second active recording | Both responses and count of Recording sessions | Sequential repeat should reject; overlapping requests need a separate concurrency experiment. |

Malformed JSON or an enum value outside the configured representation is an input-
binding case, whereas assignment and active-session checks are domain invariants. A
useful error tells the caller which state can be corrected, but avoid requiring exact
copy unless it is an agreed API contract.

## Highest-value follow-up

The exact 10% boundary deserves a fast service/integration regression check. The
overlapping-start case has higher integrity risk than an exotic malformed value:
the implementation checks for an active session before saving, so two requests can
observe the same initial state. Record this as a hypothesis until an overlapping run
or database constraint evidence confirms it.

Reset only by class agreement. A failed response is not sufficient proof of no side
effect; query sessions afterward and identify the participant/device pair.
