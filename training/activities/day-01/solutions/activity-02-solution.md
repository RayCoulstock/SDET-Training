# Activity 2 — Trainer Solution: Where Should This Test Live?

## Example placement matrix

“Primary” means the cheapest faithful signal, not the only permissible test.

| Behaviour/risk | Primary level | Why here? | What remains unproven? | Complementary signal |
| --- | --- | --- | --- | --- |
| 9% prevents recording | Unit/service | Fast, isolated boundary example with a precise failure reason. | HTTP mapping, persistence, simulator call, and UI message. | One API rejection check if response behaviour is important. |
| Exactly 10% permits recording when all else is valid | Integration | The service decision also reads participant, assignment, active sessions, and simulator status; real collaborators make this success boundary faithful. | Browser discoverability and production networking. | A smaller unit/model boundary check for rapid diagnosis. |
| Inactive participant cannot start | Unit/service | A deterministic business rule needing no browser. | API status/error representation and UI prevention or feedback. | API negative check. |
| Assigned device and participant are stored and retrieved together | Integration | The risk is EF relationship mapping and PostgreSQL persistence. | Public HTTP serialization and UI rendering. | API retrieval check if the response shape matters to a consumer. |
| API understands simulator status response | Contract | Directly detects incompatible field names/types and version drift at the external boundary. | Runtime networking, timeout behaviour, and a deployed simulator. | One integration check against the real simulator. |
| Technician can find a participant and initiate the journey | UI | Discoverability, accessible controls, routing, and browser wiring are the risk. | Every business-rule combination and concurrency. | API/service tests for the rule matrix. |
| Telemetry is persisted and retrievable | API integration | HTTP input, persistence, and retrieval are the intended observable boundary. | Browser presentation, large-volume behaviour, and production database characteristics. | Database integration check for mapping, or a thin UI display check. |

For the 10% example, a group may reasonably choose a service-level test with controlled
repositories/simulator as primary. Ask whether their fake can expose incorrect database
or simulator wiring; the quality of the justification matters more than the label.

## Deliberate overlap

- Keep many fast rule examples at service level and only a few API/browser journeys.
- Pair the simulator contract check with one runtime integration check because schema
  compatibility and reachable/configured deployment are distinct risks.
- Avoid repeating 9%, 10%, inactive, disconnected, unassigned, and active-recording
  permutations through the browser. Those checks are expensive and obscure the cause.

## Stretch: reducing the 25-minute UI suite

First inventory duration, failures/retries, covered assertions, and historical defects.
The first candidates to replace are typically (1) battery/participant rule permutations
with service or API checks and (2) telemetry persistence journeys with API integration
checks. Retain one technician journey and any genuinely browser-specific behaviour.

Before moving a check, reproduce its failure, identify whether it ever caught UI wiring
defects, compare the lower-level signal against the same mutation/known defect, and
measure suite duration and flake rate afterward. Moving a test solely because it is
slow can silently remove unique confidence.
