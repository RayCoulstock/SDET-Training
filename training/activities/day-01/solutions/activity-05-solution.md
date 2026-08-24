# Activity 5 — Trainer Solution: Why Is This Test Flaky?

## Diagnosis

The timing guess is:

```ts
await page.waitForTimeout(3000);
```

It always costs three seconds when the UI is fast and is still insufficient if the
destination takes longer. The meaningful completion condition for this check is the
visible **Participants** page heading after clicking its navigation link.

Playwright already waits for the link to be actionable before clicking. Its web-first
`expect` then retries until the destination outcome is visible, so the fixed delay can
simply be removed.

## Minimal revised test

```ts
import { expect, test } from '@playwright/test';

test('primary navigation excludes training controls', async ({ page }) => {
  await page.goto('/');
  await expect(page.getByRole('link', { name: 'Participants' })).toBeVisible();
  await page.getByRole('link', { name: 'Participants' }).click();
  await expect(page.getByRole('heading', { name: 'Participants' })).toBeVisible();
  await expect(page.getByRole('link', { name: /training/i })).toHaveCount(0);
});
```

Run the revision with:

```bash
cd tests/playwright
npx playwright test tests/navigation.spec.ts --project=chromium --repeat-each=3
```

For a fair classroom comparison, capture reporter durations before and after under the
same scenario. The theoretical avoidable floor is about 300 seconds (five minutes) per
100 executions, excluding parallelism and other work. Actual wall-clock savings depend
on worker concurrency.

## State and parallel assumptions

- `/` and `/participants` are reachable and the React application boots.
- the API is available, although the heading itself renders before participant data;
- no prior test must run, and this check writes no shared state;
- product navigation intentionally omits a Training link; and
- no other parallel test resets or disrupts the shared environment.

The heading is appropriate for what this test claims—navigation reached the Participants
page—but it does **not** establish that participant data finished loading. A test claiming
that the list is ready should instead observe a meaningful row/count or the relevant
response. Resetting shared data inside fully parallel tests can introduce races rather
than independence. Retries can gather evidence but must not become the acceptance rule
for an unexplained intermittent failure.
