# Activity 3 — Should This Become a Page Object?

**Day:** 3  
**Activity:** 3  
**Related slides:** Page Objects: What Problem Are We Solving?  
**Suggested time:** 10 minutes

## Objective

Choose the smallest useful abstraction for repeated automation based on a named problem and likely change pattern.

## Your Task

Evaluate these three candidates:

1. shared primary navigation used by most UI tests;
2. Participants search and status filters used by several focused checks;
3. the multi-step recording workflow, including its data preconditions.

For each, choose **inline test code**, **helper function**, **component object**, **Page Object**, **fixture**, or a combination. Record:

| Candidate | Repeated knowledge/problem | Chosen approach | Benefit | Cost or warning sign |
|---|---|---|---|---|

Sketch the public interface for one chosen abstraction. Use task-oriented names and keep assertions, hidden setup, and unrelated workflows out unless you can justify them. Then describe one future change it would absorb and one change that would still require test edits.

## Things to Investigate

- Is repeated code actually repeated knowledge?
- Would the abstraction name a user interaction or mirror DOM elements?
- Does it make the test's arrange/action/assert flow clearer?
- Are API setup and data ownership really page responsibilities?
- When would a Page Object become a “god page”?

## Evidence

Bring the completed comparison, one interface sketch, and one candidate you deliberately kept inline.

## Stretch Challenge

Describe the evidence you would wait for before introducing the rejected Page Object later.

## Hints

1. Different candidates may need different abstraction types.
2. Centralisation has a maintenance cost as well as a benefit.
3. Start with the problem statement, not a class name.

## Discussion

- Which abstraction choice was most contested?
- What should never be hidden from the reader of a test?
- How would you tell whether the abstraction still earns its cost in six months?
