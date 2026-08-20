# Activity 4 — Find the Most Resilient Locator

**Day:** 1  
**Activity:** 4  
**Related slides:** What Makes a Locator Resilient?; Accessibility and Testability Reinforce Each Other  
**Suggested time:** 15 minutes

## Objective

Compare locator strategies by user intent and likely resilience, and recognise when the interface itself limits a good automation choice.

## Before You Start

Make sure NeuroPulse is running and open the application and `tests/playwright` project. You may use browser developer tools or Playwright's locator tooling to inspect elements.

## Your Task

Investigate these controls:

1. the Participants search field;
2. the Devices connection filter; and
3. **Start Recording** on the detail page of a participant who has an assigned device.

For each control, record at least two possible ways to locate it. Rank the options from most to least resilient and explain what user-facing identity—or implementation detail—each relies on.

Try your preferred locator in a small test or with Playwright's tooling. Reload or revisit the page and check whether your reasoning still holds. If the locator you would ideally use does not work, capture that as a product testability observation rather than silently choosing a brittle alternative.

## Things to Investigate

- Can the control be found by role and accessible name, or by its label?
- Would visible text uniquely express its purpose?
- Does any attribute change between renders?
- Would a CSS selector survive a layout or styling refactor?
- Can the control be reached and operated with a keyboard?
- Is the best available locator also the best interface for a user?

## Evidence

Create a short comparison table:

| Control | Candidate locators | Preferred choice | Evidence and trade-off |
| --- | --- | --- | --- |

Include one working locator experiment and one product observation. You are not expected to change the React application.

## Stretch Challenge

Describe the smallest interface change that would make your least satisfactory control easier to use and automate. State which locator would become possible; do not implement the change.

## Hints

1. Start with role or label, then text, then a purposeful test ID; use CSS only when you can justify it.
2. Inspect both the DOM and the accessibility information exposed by the browser.
3. A locator that fails for a semantic reason can be useful evidence about the product.

## Discussion

- Which locator best communicates the user's intent?
- What page change would break each candidate?
- When should a testability problem lead to a product change rather than a cleverer selector?
