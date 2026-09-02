# Activity 2 — Remove the Repeated Setup

**Day:** 3  
**Activity:** 2  
**Related slides:** Setup Is Part of Test Design; Fixtures: Reusable Context, Explicit Ownership  
**Suggested time:** 15 minutes

## Objective

Replace repeated UI preparation with an explicit setup strategy that preserves the behaviour under test and supports isolation.

## Scenario

Three proposed tests each open Participants, create a participant through the form, locate a device, and navigate to a detail page before testing different recording outcomes.

## Your Task

Select one proposed outcome: start a valid recording, reject an ineligible participant, or display a recording result. Mark every setup step as:

- behaviour this test must exercise;
- state that may be established directly; or
- irrelevant work that should be removed.

Use `docs/api-reference.md`, the Postman collection, and Playwright's `request` fixture to sketch a fixture or helper that owns the necessary participant/device/session state. Show its inputs, returned data, scope, and teardown or uniqueness strategy. Pseudocode is sufficient; a small TypeScript implementation is optional.

Account for the fact that the API has no delete route. Do not use a global training reset inside a parallel test. State which data the setup owns, what it cannot clean up, and how a unique value or bounded seeded record affects repeatability.

## Things to Investigate

- Would API setup bypass the behaviour the test claims to prove?
- Should the resource live for one test or a worker?
- Is a fixed database identifier an explicit contract or an accidental dependency?
- How will another test avoid colliding with this data?
- Does fixture convenience hide an important precondition?

## Evidence

Show the setup classification, fixture/helper sketch, resource ownership and lifetime, and one acknowledged limitation.

## Stretch Challenge

Compare a fixture with a plain helper for this use. Which makes dependencies clearer at the call site?

## Hints

1. Use the UI when the setup interaction itself is under test.
2. A timestamp or worker identifier can make synthetic values distinguishable, but uniqueness does not provide cleanup.
3. Make the returned identifiers explicit rather than rediscovering them through the UI.

## Discussion

- Which repeated step did you retain, and why?
- How does your design behave under `fullyParallel`?
- What repository limitation most affects the lifecycle strategy?
