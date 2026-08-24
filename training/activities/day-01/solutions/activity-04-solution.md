# Activity 4 — Trainer Solution: Find the Most Resilient Locator

## Locator comparison

| Control | Candidate locators, strongest first | Preferred choice | Evidence and trade-off |
| --- | --- | --- | --- |
| Participants search | `getByRole('textbox', { name: 'Search participants' })`; `getByLabel('Search participants')`; `getByPlaceholder('Search name or email')`; `locator('.filters input')` | Role + accessible name (or `getByLabel`) | It identifies the textbox as assistive technology does. Placeholder wording is more likely to change; the CSS option depends on layout. |
| Devices connection filter | `getByRole('combobox', { name: 'Connection' })`; `getByLabel('Connection')`; `locator('.filters select').first()` | Role + accessible name | The `aria-label` supplies stable purpose. `.first()` silently depends on DOM order and styling structure. |
| Start Recording | `getByText('Start Recording', { exact: true })`; `locator('.start-action')`; `[id^="start-session-"]` | Visible text, but none is satisfactory | Text conveys purpose, yet the element is a clickable `div`: it has no button role, is not normally keyboard actionable, and its random ID changes each render. |

`getByRole('button', { name: 'Start Recording' })` is the ideal expression but currently
does not match. That failure is useful product evidence, not a reason to use the random
ID.

## Working locator experiment

```ts
import { expect, test } from '@playwright/test';

test('semantic locator experiment', async ({ page }) => {
  await page.goto('/participants');
  const search = page.getByRole('textbox', { name: 'Search participants' });
  await expect(search).toBeVisible();
  await search.fill('Sarah');
  await expect(page.getByRole('link', { name: 'Sarah Miller' })).toBeVisible();

  await page.goto('/devices');
  const connection = page.getByRole('combobox', { name: 'Connection' });
  await expect(connection).toBeVisible();
  await connection.selectOption({ label: 'Connected' });
});
```

## Product observation and smallest improvement

Render Start Recording as a native `<button type="button">Start Recording</button>`
(and preserve appropriate disabled/focus behaviour). This makes
`getByRole('button', { name: 'Start Recording' })` possible and gives keyboard and
assistive-technology users the correct semantics. Adding a test ID alone would aid
automation but would not repair the interface.

During debrief, distinguish resilience from permanence: accessible wording can change,
but a test failure after an intentional user-facing rename is informative. A selector
that survives by ignoring user meaning may instead let a regression pass.
