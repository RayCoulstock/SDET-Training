# Activity 1 — Trainer Solution: Review the Growing NeuroPulse Suite

## Example review

| Area and observation | Repository evidence | Risk at 300 tests | Priority | Smallest useful response |
| --- | --- | --- | --- | --- |
| Organisation: three flat specs are currently easy to scan | `tests/` contains navigation, API, and UI smoke specs | Mixed features/levels become hard to own and select | Later | Group by feature and name level when growth makes navigation costly; do not reorganise three files now. |
| Data/state: API spec assumes Sarah is array item 0 with id 1 | Exact seeded object assertion | Resets, inserts, or parallel mutation produce unrelated failures | High | Query by stable test-owned value or make the seed dependency explicit in a seed smoke check. |
| Data/state: browser contexts are isolated, PostgreSQL is not | `fullyParallel: true`; shared API/database | Stateful checks collide even with fresh pages | Highest | Design unique owned records/reserved fixtures; prohibit per-test global reset. |
| Speed: navigation always waits three seconds | `waitForTimeout(3000)` | Roughly 15 minutes of serial delay per 300 executions before browser/project multiplication | High | Remove it and wait on the meaningful heading/outcome. |
| Diagnosis: screenshot is only on failure and trace only on first retry | Playwright `use` configuration | First attempt has screenshot; retry has trace, which is useful but retry can make an intermittent build green | Medium | Keep initially, report flaky/retried tests, and retain artefacts; tune only from diagnostic evidence. |
| Placement: future rule permutations are planned in UI | Scenario says filters, assignment, and recording growth | Slow suite with poor fault localisation | High | Put rule matrices/service contracts below UI; retain thin browser journeys. |

## Priorities

1. **Shared persistent state under full parallelism** can create incorrect pass/fail
   results and corrupt another check's preconditions. Establish ownership and unique
   setup before adding stateful tests.
2. **Test placement plus the fixed delay** will rapidly inflate feedback time. Remove
   the known delay immediately, then require each new browser test to justify the UI-
   specific risk it covers.

One retry is diagnostic when the initial artefact is retained and the retry difference
is visible; treating a retry-pass as ordinary success conceals instability. A browser
context does not isolate database or simulator state.

## Deliberate non-change

Do not introduce a Page Object hierarchy or elaborate folders for the current three
small specs. Wait for repeated domain interaction knowledge and ownership boundaries.
A plausible future layout is `tests/participants/`, `tests/devices/`, and
`tests/sessions/`, with API/service portfolios outside the browser project rather than
placing every check beneath an `e2e` label.
