# Activity 5 — Trainer Solution: Ask AI to Test This

## Human design first: Start Recording

| Idea | Risk and expected evidence |
| --- | --- |
| Battery 9%, 10%, and 11% with all other state valid | Inclusive threshold is implemented incorrectly; observe rejection at 9 and success at 10/11 through fast service checks. |
| Two overlapping starts for one device | Both requests pass the active-session check; observe responses and assert at most one Recording row, backed by a database invariant. |
| Simulator reports disconnected/unavailable while stored device says connected | Stale local state starts a recording; control provider response and observe a clear rejection with no saved session. |

Ambiguities include whether live or stored battery is authoritative, expected status
codes/error schema, and behaviour when the simulator cannot be reached.

## Example prompts

An intentionally weak first prompt is:

> Here is the Start Recording user story: [story text]. Give me test cases.

It may produce useful boundary/state ideas but can easily invent authentication,
routes, response codes, deletion, or device behaviour. Mark every such claim for
verification.

A stronger second prompt is:

> Using only this story and the documented `POST /api/sessions` request containing
> `participantId` and `deviceId`, propose at most eight risk-ranked checks. Include
> controlled preconditions, test level, expected observable evidence, and a separate
> assumptions column. Cover the inclusive 10% boundary and concurrency. Do not invent
> routes, status codes, authentication, or cleanup; label missing decisions.

## Example evaluation

| Suggestion | Classification | Verification/reason |
| --- | --- | --- |
| Test 9/10/11% | Keep | “At least 10%” is in the story. |
| Reject inactive participant | Keep | Explicit story rule. |
| `POST /api/recordings/start` returns `409` | Unsupported | Repository documents `POST /api/sessions`; status semantics are not stated by the story. |
| Try SQL injection in participant name | Low value here | Not connected to this bounded start decision; security work needs its own risk model. |
| Retry simulator failures automatically | Unsupported | This invents product recovery behaviour. |
| Concurrent double submit | Adapt | High-value idea, but specify controlled state and invariant rather than only two clicks. |

The improved prompt reduces scope and makes uncertainty visible; it cannot settle the
ambiguous product decisions or prove any expected outcome. Human reviewers own the
portfolio, safe execution, privacy, technical verification, and final consequence.
Generated questions and answers require human review before course delivery.
