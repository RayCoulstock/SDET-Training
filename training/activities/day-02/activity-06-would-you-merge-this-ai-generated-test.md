# Activity 6 — Would You Merge This AI-Generated Test?

**Day:** 2  
**Activity:** 6  
**Related slides:** Would You Merge This?; The Risk Ledger  
**Suggested time:** 15 minutes

## Objective

Apply ordinary test-design and code-review standards to a plausible AI-generated Playwright test.

## Candidate

```ts
import { expect, test } from '@playwright/test';

test('starts recording', async ({ page }) => {
  await page.goto('/participants/1');
  await page.locator('#start-session-48372').click();
  await page.waitForTimeout(5000);
  expect(await page.locator('.badge').innerText()).toBe('Recording');
});
```

## Your Task

Review the candidate as if it were a pull request. Do not begin by rewriting it.

1. State the behaviour the test appears to claim.
2. Add review comments under **intent**, **truth**, **synchronisation**, **isolation**, **diagnostics**, and **maintainability**.
3. Label each comment **blocker**, **important**, or **suggestion**, with a reason.
4. Verify at least two assumptions by inspecting the UI, `tests/playwright`, the user story, or browser network traffic.
5. Write a short merge decision: approve, request changes, or close in favour of a different test level.
6. Outline the smallest verification plan for an improved test. You may include pseudocode, but prioritise the design rather than producing a large implementation.

Treat AI authorship as irrelevant to the quality bar: review the observable claim and evidence.

## Things to Investigate

- What preconditions does participant `1` need, and where are they established?
- Does the selector express user intent and remain stable across renders?
- What condition should replace elapsed time as the synchronisation signal?
- Could a different badge satisfy the assertion?
- Would an API check give faster evidence for some part of this rule?

## Evidence

Show your categorised review, two verified assumptions with their sources, a merge decision, and an improvement plan.

## Stretch Challenge

Split the claimed behaviour into a small test portfolio. Explain what belongs at service/API level and what one focused UI check uniquely proves.

## Hints

1. Recall Day 1 guidance on semantic locators, web-first assertions, and independent setup.
2. Inspect the rendered control more than once before deciding whether its identifier is stable.
3. A test can pass while proving less than its title promises.

## Discussion

- Which issue is the highest-risk blocker, and why?
- What evidence changed your initial review?
- How would you give the same feedback constructively to any contributor?
