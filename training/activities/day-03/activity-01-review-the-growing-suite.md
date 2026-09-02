# Activity 1 — Review the Growing NeuroPulse Suite

**Day:** 3  
**Activity:** 1  
**Related slides:** From Tests to a Suite  
**Suggested time:** 15 minutes

## Objective

Identify and prioritise the maintenance, speed, state, and diagnostic risks that emerge as a small test collection grows.

## Before You Start

Inspect `tests/playwright/playwright.config.ts` and the three specs in `tests/playwright/tests/`. Do not refactor yet.

## Scenario

The team expects the starter checks to grow into coverage for participant filters, device assignment, and recording sessions. Several engineers will add and run tests concurrently in CI.

## Your Task

Create a review table:

| Observation | Evidence in the repository | Risk at 300 tests | Priority | Smallest useful response |
|---|---|---|---|---|

Include at least one observation about each of **organisation**, **data/state**, **execution speed**, **failure diagnosis**, and **test placement**. Separate an immediate problem from a risk that appears only as the suite grows.

Choose your top two risks. For each, explain the failure mode it could create and why you would address it before the other findings. Do not recommend a framework or Page Object merely because it is conventional.

## Things to Investigate

- What does `fullyParallel` imply for shared seed records and global resets?
- What could one retry reveal, and what could it conceal?
- Which starter test depends on a particular record rather than creating its own state?
- Are screenshots and traces captured at the moment they are most useful?
- Which future behaviours belong below the browser?

## Evidence

Bring the completed table, two prioritised risks, and one choice to leave the current suite unchanged for now.

## Stretch Challenge

Sketch a directory structure for 300 checks. Explain which organising principle helps a contributor locate ownership and intent.

## Hints

1. Read configuration as part of suite design, not just test files.
2. A concise starter is not automatically a scalable pattern.
3. Prefer a specific failure mode over “this is not best practice.”

## Discussion

- Which risk increases fastest under parallel execution?
- What should be solved by test placement rather than abstraction?
- Which recommendation buys the most confidence for the least complexity?
