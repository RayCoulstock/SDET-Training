# Activity 6 — Trainer Solution: Investigate a Failed Test

## Safe demonstration

Copy the smoke check to a temporary spec and deliberately expect a heading that the
product does not render:

```ts
import { expect, test } from '@playwright/test';

test('temporary diagnostic example', async ({ page }) => {
  await page.goto('/participants');
  await expect(
    page.getByRole('heading', { name: 'Study Participants' }),
  ).toBeVisible();
});
```

Run it, inspect the generated evidence, then delete it:

```bash
cd tests/playwright
npx playwright test tests/temporary-failure.spec.ts --project=chromium
npm run report
rm tests/temporary-failure.spec.ts
npm test
```

`npm run report` starts an interactive report server, so in a non-interactive teaching
setup the trainer may instead open `playwright-report/index.html` or use
`npx playwright show-report --host 0.0.0.0` and follow the displayed URL.

## Example evidence record

1. **Assertion output:** the locator for heading “Study Participants” resolved to no
   visible element before timeout.
2. **Screenshot/HTML report:** the browser is on the Participants page and visibly
   shows the heading “Participants”; navigation and application rendering occurred.
3. **Retry trace (when available):** `page.goto` completed and the snapshot contains
   the real heading. Network events can be checked for unexpected API failures, but
   the heading discrepancy does not require participant data.

The supported observation is only that the expected heading was absent while
“Participants” was present. The likely cause must remain a hypothesis until the
expectation is compared with requirements or an approved design.

## Example causal hypothesis

> I think the temporary test has a stale or deliberately incorrect expectation because
> the assertion, screenshot, and retry snapshot show successful navigation and the
> heading “Participants”; next I would compare the requirement and recent UI changes
> to distinguish it from an unintended product copy regression.

A competing explanation is that the product heading really should be “Study
Participants.” Evidence of rendered text alone cannot decide which wording is correct.

## If the trace shows an unsuccessful API request

Inspect the API service logs first because the browser calls the NeuroPulse API at the
`/api` boundary:

```bash
docker compose logs --since=10m api
```

Then correlate its timestamp/status with browser network evidence and, if the API log
shows a simulator call failure, inspect `device-simulator` logs. For a CI-only failure,
preserve the trace, screenshot, report, console/network output, service logs, scenario,
seed/reset history, commit, browser version, and retry comparison.

End by verifying that `git status --short` contains no temporary spec and that the
normal suite has no intentional failure.
