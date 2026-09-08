# Activity 5 — Trainer Solution: AI as Pair Tester

## Example bounded evidence pack

```text
Purpose: navigate from Dashboard to Participants and prove the destination heading.
Code: click the Participants role-based link; wait 3000 ms; expect heading visible.
Concern: every run waits 3000 ms; a fixed delay may still be shorter than completion.
Timeline: click at 0 ms; fixed wait ends near 3000 ms; assertion then executes.
Configuration: fullyParallel=true, retries=1, screenshot on failure, trace on first retry.
Question: rank causes and propose the next observation; do not assume a fix.
```

This pack contains no sensitive data and omits a preferred solution.

## Example response classification

| Possible AI claim | Classification | Human verification |
| --- | --- | --- |
| Playwright assertions such as `toBeVisible` retry until timeout | Supported | Installed Playwright types/documentation and a minimal run support it. |
| `click()` waits for the destination heading | Incorrect | Click actionability does not establish an application-specific rendered outcome. |
| The Participants API is necessarily the cause | Needs verification | The static heading can render independently; inspect trace/network rather than infer. |
| Increase the test timeout to ten seconds | Irrelevant/unsafe first response | It retains the timing guess and does not distinguish failure categories. |
| Replace the sleep with a web-first heading assertion | Supported as smallest change for the stated claim | Run repeated comparison and inspect trace duration. |

## Owned next action

The engineer, not the model, removes the wait in a temporary comparison, runs it
repeatedly, and retains trace/network evidence for any failure. If the test instead
claims list readiness, change the observable condition to a meaningful row or response.
The model adds value by forcing hypotheses and falsifying observations into a table;
it supplies no repository truth and cannot decide whether the test's stated purpose is
the correct product requirement.

Before course delivery, a human must review any generated answer for technical accuracy,
ambiguity, accessibility, and learning-outcome alignment.
