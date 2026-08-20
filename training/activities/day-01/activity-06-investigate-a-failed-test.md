# Activity 6 — Investigate a Failed Test

**Day:** 1  
**Activity:** 6  
**Related slides:** Debug the System, Not Just the Line  
**Suggested time:** 10 minutes

## Objective

Use Playwright evidence to distinguish the failure location from a plausible root cause and choose the next diagnostic action.

## Before You Start

Make sure NeuroPulse is running. Preserve your working tests and make this experiment in a temporary spec or temporary branch. The Playwright configuration produces an HTML report, failure screenshots, and a trace on the first retry.

## Scenario

A browser check has failed in a build. The assertion message identifies where the runner stopped, but the team does not yet know whether the test, browser state, UI, API, data, or a dependency caused the observed difference.

## Your Task

Choose one working navigation or list-page check. In your temporary copy, change one expected visible value so that the assertion fails predictably; do not break application code.

Run the failing check and investigate at least two evidence sources:

```bash
cd tests/playwright
npx playwright test tests/<temporary-spec>.spec.ts --project=chromium
npm run report
```

Use the assertion output, screenshot, HTML report, and retry trace as available. Write a one-sentence causal hypothesis in this form:

> I think ___ because the evidence shows ___; next I would inspect or run ___ to distinguish it from ___.

You are diagnosing, not fixing. After preserving your notes, remove the temporary failing test and confirm that no intentional failure remains.

## Things to Investigate

- What did the assertion expect, and what was actually visible?
- Did navigation and preceding actions complete?
- Did the same failure occur on the retry?
- What DOM or network activity preceded the assertion?
- Which claim is directly supported, and which part is still a hypothesis?
- What is the cheapest next observation that could disprove your hypothesis?

## Evidence

Be ready to show:

- the failed assertion and actual observation;
- two evidence sources you consulted;
- a supported hypothesis and a competing explanation; and
- one next diagnostic action.

Do not include the deliberately incorrect test in work you keep or commit.

## Stretch Challenge

Identify which service log you would inspect if the trace showed an unsuccessful `/api` request, and write the repository command you would use without needing to run it.

## Hints

1. Begin with the assertion message, then reconstruct what happened immediately before it.
2. The trace can connect actions, page state, and network requests over time.
3. “The assertion failed” describes a symptom, not a cause.

## Discussion

- Which evidence changed or strengthened your first explanation?
- How would you distinguish a product defect from a bad expectation?
- What would you collect next if the failure happened only in CI?
