# Activity 1 — Trainer Solution: What Makes This Difficult to Test?

## Dependency path

`SessionService.Start` reads participant and device through `AppDbContext`, evaluates
stored eligibility, queries Sessions, calls the injected simulator `HttpClient`, waits
80 ms, obtains `DateTime.UtcNow` and two `Random.Shared` values, adds a session, and
saves PostgreSQL state. `Stop` reads the session, checks Recording status, obtains UTC
time, and saves the update.

## Testability map

| Dependency/outcome | Entry into behaviour | Control / observation / determinism | Failure risk | Candidate level |
| --- | --- | --- | --- | --- |
| Participant, device, assignment, stored battery/connection | EF queries through injected context | Controllable with database setup; returned errors observable; deterministic if state isolated | Incorrect rule/order or mapping | Fast service tests plus PostgreSQL integration |
| Existing Recording session | EF `AnyAsync` | Controllable, but parallel writers undermine isolation | Duplicate active sessions | Database/concurrency integration |
| Simulator V1 status | injected typed `HttpClient` GET by serial | Base client is replaceable; response/timeout can be controlled; current error string is observable but coarse | Provider failure or incompatible representation | Consumer contract + focused HTTP/integration |
| Fixed delay | direct `Task.Delay(80)` | Not controllable or observable as domain state; deterministic duration still slows tests | Widens race and suite runtime | Avoid in rule unit tests; concurrency experiment |
| Start/end time | direct `DateTime.UtcNow` | Cannot choose exact instant; only observe returned/saved value within a range | Boundary and flaky timestamp assertions | Focused service test with clock seam |
| Signal and quality | `Random.Shared` | Cannot choose result; output observable but nondeterministic | Unrepeatable boundary examples | Controlled generator test plus real invariant checks |
| Saved session/result | EF add/save and tuple return | Observable in return and DB; deterministic only with isolated state | Save/constraint failure, partial assumptions | PostgreSQL integration |

The returned rejection reason locates a rule at a high level but lacks correlation id,
dependency status/latency, and structured failure category. Catching every simulator
exception and exposing its message also mixes diagnostics with caller-facing content.

## Ranked constraints

1. **No atomic protection for the active-session invariant.** Two Start calls can both
   pass `AnyAsync` before either save, and the deliberate delay enlarges this window.
   A substitute database would miss real transaction/constraint behaviour; retain
   PostgreSQL for the concurrency check and consider a database invariant/transaction.
2. **Direct time/randomness/delay obstruct controlled fast feedback.** Exact boundary
   examples are awkward and repeated service runs cost time. A narrow clock or result
   generator seam should be earned by a named test, not interfaces for every class.

Keep PostgreSQL real in mapping, query, constraint, and concurrency tests. Control does
not equal isolation: two tests can receive controllable clients yet still share the
same database rows.
