# Activity 3 — Your First NeuroPulse Test

**Day:** 1  
**Activity:** 3  
**Related slides:** Playwright: A Mental Model; A First NeuroPulse Test  
**Suggested time:** 25 minutes

## Objective

Create one readable Playwright test that demonstrates an observable user outcome without becoming a large end-to-end journey.

## Before You Start

Make sure the training application is running using the setup in the course `README.md`. The Playwright project lives in `tests/playwright` and uses `http://localhost:3000` by default.

If the Playwright dependencies were not installed during course setup, run:

```bash
cd tests/playwright
npm install
npx playwright install chromium
```

Work on a short-lived branch or in a new spec file so that the starter examples remain recoverable.

## Scenario

The existing smoke test proves that the Participants page can open. The team needs one more small check around a user-visible outcome on **Participants**, **Devices**, or **Sessions**.

## Your Task

Explore the three pages and choose one behaviour worth checking. State the behaviour in plain English before writing code. Then add one independent Playwright test with a clear arrange/action/assert flow.

Useful candidates include searching or filtering a list, navigating from a list to a detail, or confirming a visible status. Choose your own assertion; do not attempt the complete Start Recording workflow.

Run your test directly while developing, then run the complete starter suite:

```bash
cd tests/playwright
npx playwright test tests/<your-spec>.spec.ts --project=chromium
npm test
```

## Things to Investigate

- What user outcome does the test prove rather than merely what code does it execute?
- Which locator expresses user-recognisable intent?
- Is the assertion specific enough to catch a regression?
- Does the test depend on another test running first?
- Is the seed-data assumption visible and reasonable?
- If the check failed, would its name and assertion explain the intended behaviour?

## Evidence

Be ready to show:

- the plain-English behaviour you selected;
- the new test;
- a passing result for that test;
- the complete suite result; and
- one limitation: something your test deliberately does not prove.

## Stretch Challenge

Run your new test several times with `--repeat-each=3`. Decide whether repeated success meaningfully increases confidence and identify one source of state coupling that repetition might reveal.

## Hints

1. Begin from the starter pattern in `tests/playwright/tests/ui-smoke.spec.ts`.
2. Prefer a role, accessible name, or label that a user would recognise.
3. Keep the check narrow: one purposeful interaction and one or two meaningful assertions are enough.

## Discussion

- What makes the test readable to someone who did not write it?
- What risk does it cover, and at what cost?
- What would make the same check unreliable in CI?
