# Activity 6 — Trainer Solution: Would You Merge This AI-Generated Test?

## Apparent claim and decision

The candidate appears to claim that a technician can start a recording from participant
1 and see Recording status. **Request changes**: its setup and selectors do not establish
that outcome, and elapsed time is used instead of a meaningful completion condition.

## Review findings

| Category | Priority | Review comment |
| --- | --- | --- |
| Intent/truth | Blocker | Participant `1` alone does not establish an active participant, assigned/connected device, battery, simulator availability, or absence of an active recording. Please create/identify controlled preconditions and assert the returned session identity so the test cannot pass on old state. |
| Maintainability/accessibility | Blocker | `#start-session-48372` is not stable: the rendered id contains a new random suffix, and the clickable `div` has no button semantics. Please make the product control a native button, then locate it by role and accessible name. |
| Synchronisation | Important | Five seconds is both unconditional delay and insufficient under slower conditions. Wait for the session-start response and assert the destination/session-specific Recording outcome with Playwright's web-first assertion. |
| Diagnostics/truth | Important | `.badge` can resolve to participant, connection, or session badges, and `innerText()` plus a non-retrying Jest-style assertion loses web-first waiting. Scope a locator to the created session/status region and use `await expect(locator).toHaveText(...)`. |
| Isolation | Blocker | Starting a session mutates persistent shared data while tests run fully parallel. Give this test uniquely owned setup or a deliberately reserved record and state the lifecycle; do not reset shared data inside the test. |

## Verified assumptions

- The UI creates `start-session-<random number>` during render, so the literal selector
  is unreliable and does not express user intent.
- The service requires active participant, correct assignment, stored connection,
  battery of at least 10%, no active recording, and a connected V1 simulator response.

## Smallest improvement plan

1. Establish or reserve one eligible participant/device through explicit API setup;
   record their returned identifiers and confirm Normal simulator state.
2. Navigate to that participant and operate a semantic Start Recording button. Product
   work is required before `getByRole('button', { name: 'Start Recording' })` matches.
3. Capture the `POST /api/sessions` response, require `201`, take its returned session
   id, and assert navigation/details for that same id and Recording status.
4. Run repeatedly and in parallel with another stateful check; retain trace/network
   evidence on failure.

Keep most eligibility permutations at service/API level. One focused UI journey earns
its place by proving control semantics, browser-to-API wiring, navigation, and rendered
feedback—not every rule combination.
