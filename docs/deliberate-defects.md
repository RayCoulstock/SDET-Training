# INSTRUCTOR MATERIAL — Deliberate defects

Do not distribute this as an exercise solution. Each item records **location; expected vs actual; trigger; teaching/discovery; reset**.

1. **UI-only participant validation** — `Participants` form / participant POST. Required identity fields should be rejected everywhere; the UI rejects them but the API accepts blanks. Send a direct Postman request. API boundaries/testing. Reset data.
2. **Impossible assignment** — device assign endpoint. Only active participants should receive a device; the endpoint merely checks existence and accepts inactive participant 10 or 12. Negative business-rule testing. Reset data/unassign.
3. **Unstable selector** — participant detail start action. Stable controls are expected; its generated `start-session-*` id changes per render. Inspect DOM/reload; locator coaching. No reset required.
4. **Poor semantic action** — participant detail. Start Recording should be a button but is a clickable `div`. Accessibility tree and role locator expose it. No reset.
5. **Arbitrary timeout** — `tests/playwright/tests/navigation.spec.ts`. State-based waiting is expected; test sleeps three seconds. Code review/auto-waiting. Always enabled.
6. **Duplicated setup** — starter Playwright specs repeat navigation/API acquisition rather than fixtures. Review suite structure; discuss helpers and POMs. Always enabled.
7. **Start-state race** — participant detail and `SessionService`. API persists after a delay while UI performs an immediate follow-up; latency/repeated interaction makes transient state visible. Async/flakiness. Choose Normal.
8. **Direct randomness** — simulator telemetry and `SessionService`. Reproducible readings would be preferable; `Random.Shared` is concrete. Inspect code/results. Restart/reset does not seed it.
9. **Direct system clock** — `SessionService`. Tests cannot control `DateTime.UtcNow`. Unit-test design/code review. Requires refactoring to disable.
10. **Coupled session service** — `SessionService` directly uses EF context, concrete typed HTTP, time, and randomness. Unit isolation is awkward. Design-for-testability workshop. Always enabled.
11. **Breaking provider contract** — simulator V2. Consumer expects `{deviceId, connected, battery}` but receives `{id,status,batteryPercent}`. Select Contract Breaking Change and start a session. Pact. Select Normal/V1.
12. **Slow behaviour** — participant search has a fixed delay; simulator adds up to 5 seconds through controls. Observe network waterfall/timeouts. Performance exploration. Normal/0 ms.
13. **Telemetry bottleneck** — telemetry POST performs a separate read and write and adds 45 ms in High Volume mode. JMeter reveals latency under bounded load. Select Performance Stress; reset Normal.
14. **Duplicate start** — `SessionService` checks then delays then inserts without transaction/idempotency. Send parallel valid start requests. Concurrency/idempotency. Reset data.
15. **Poor error message** — participant start UI. Useful API detail is replaced with “Something went wrong.” Trigger a disconnected or low-battery device. DevTools/debugging. Use valid device.
16. **Stale status scenario** — Exploratory configuration exposes `staleStatus`; status consumers have no freshness contract and persisted UI state can disagree with simulator. Compare device page and simulator. Distributed consistency. Normal.
17. **Duration edge** — UI computes raw timestamp subtraction without guarding a negative interval; persistence has no ordering constraint. Manipulated data can render negative minutes. Boundary/time testing. Reset.
18. **Missing telemetry bounds** — telemetry POST stores quality outside 0–1 and nonsensical signal/battery values. Send `quality: 4.7`. API negative testing. Reset.
19. **External availability randomness** — Unreliable Device uses direct random 12% failures. Repeated simulator status calls reveal intermittent 503s. Flaky systems. Normal.
20. **Contract/training state is process-local** — simulator controls are lost on restart. A durable production control might be expected, but this safe training mechanism resets unexpectedly. Restart simulator; environment reasoning. Reapply preset.
