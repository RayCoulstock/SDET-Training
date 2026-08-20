# Activity 5 — Why Is This Test Flaky?

**Day:** 1  
**Activity:** 5  
**Related slides:** Waiting in an Asynchronous UI; Test Independence Is Designed  
**Suggested time:** 15 minutes

## Objective

Replace a timing guess with observation of the condition that represents completion, then check the test's state assumptions.

## Before You Start

Make sure NeuroPulse is running in the **Normal** scenario. Open `tests/playwright/tests/navigation.spec.ts` and run it once:

```bash
cd tests/playwright
npx playwright test tests/navigation.spec.ts --project=chromium
```

## Scenario

The navigation test passes, but a passing test can still contain a reliability and speed risk. A teammate proposes increasing all waits and relying on the configured retry if CI becomes slower.

## Your Task

Review the test and identify where it guesses elapsed time rather than observes application state. Write down the meaningful condition that should tell the test navigation is complete.

Make the smallest test-only change that waits for or asserts that condition instead. Compare the original and revised test by running each several times. Also list the state assumptions the check makes and decide whether it could run alone and alongside the other specs.

Do not add another fixed delay, raise the global timeout, or increase retries.

```bash
npx playwright test tests/navigation.spec.ts --project=chromium --repeat-each=3
```

Restore or retain the changed test as your trainer directs after preserving your comparison.

## Things to Investigate

- Which Playwright actions already wait for an element to become actionable?
- What visible outcome means that the requested page is ready for this check?
- Does a locator identify the destination before its content has updated?
- How much time does the fixed delay add even when the application is fast?
- Does this test modify shared state or rely on deterministic seed data?
- Would a training-data reset inside a fully parallel suite make tests more independent—or introduce a new race?

## Evidence

Be ready to show:

- the timing guess you found;
- the completion condition you chose and why;
- the minimal revised test;
- repeated-run results for the revision; and
- one state or parallel-execution assumption.

## Stretch Challenge

Use the Playwright report or command timings to estimate the avoidable cost of the original wait over 100 executions. Explain why a faster test is not automatically a reliable test.

## Hints

1. Look for a statement that waits for a duration rather than a state.
2. A web-first `expect` retries until its condition is met.
3. Assert the business-visible outcome, not an internal loading mechanism.

## Discussion

- Why can a fixed wait be both too long and too short?
- What evidence suggests the revised test observes the right completion condition?
- When can a reset or retry hide coupling rather than solve it?
