# Activity 3 — Trainer Solution: Your First NeuroPulse Test

## Selected behaviour

> Searching Participants for “Sarah Miller” leaves Sarah's matching record visible
> and removes a known non-matching record.

This is a narrow user outcome: search changes the rendered participant list. It avoids
creating data and can therefore run independently against the Normal seed state.

## Sample Playwright spec

Save as `tests/playwright/tests/participant-search.spec.ts` while demonstrating:

```ts
import { expect, test } from '@playwright/test';

test('a technician can filter participants by name', async ({ page }) => {
  // Arrange
  await page.goto('/participants');
  await expect(page.getByRole('heading', { name: 'Participants' })).toBeVisible();

  // Act
  await page.getByLabel('Search participants').fill('Sarah Miller');

  // Assert
  await expect(page.getByRole('link', { name: 'Sarah Miller' })).toBeVisible();
  await expect(page.getByRole('link', { name: 'Daniel Carter' })).toHaveCount(0);
});
```

The web-first assertions wait for the asynchronous request and rerender; no fixed delay
is required. The accessible label describes intent better than a CSS class or DOM path.
The positive assertion prevents an empty list from passing, while the negative assertion
shows that filtering occurred.

## Run commands

```bash
cd tests/playwright
npx playwright test tests/participant-search.spec.ts --project=chromium
npm test
npx playwright test tests/participant-search.spec.ts --project=chromium --repeat-each=3
```

## Limitations and debrief

The test assumes Normal deterministic seed data and proves neither arbitrary search
terms nor API/database correctness in isolation. It also does not prove case handling,
email search, status filtering, accessibility beyond locator availability, or the full
recording workflow.

Repeated success can expose intermittent timing/state coupling but is not proof of
reliability. A concurrent reset or a test that creates/deletes Sarah would couple this
check to shared state. An equally good learner example may filter Devices or navigate
to details if it is independent, semantic, and asserts a specific visible outcome.
