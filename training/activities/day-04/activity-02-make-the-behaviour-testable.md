# Activity 2 — Make the Behaviour Testable

**Day:** 4  
**Activity:** 2  
**Related slides:** Time Is an Input; Randomness Is Also an Input; External Dependencies and Test Seams  
**Suggested time:** 20 minutes

## Objective

Propose the smallest seam that makes one important NeuroPulse behaviour controllable and deterministic without claiming that a controlled test replaces integration evidence.

## Scenario

The team has time for one focused testability improvement. A broad rewrite or “mock everything” proposal is unlikely to be accepted, so the recommendation must connect a specific risk, design change, and test.

## Your Task

Choose **one** behaviour:

- set and verify a session start or end timestamp at a boundary instant;
- generate a predictable signal and quality result;
- decide session eligibility from a Device Simulator status response; or
- investigate repeated start requests without waiting in real time.

Write a one-sentence risk and show the current dependency path. Design the smallest useful seam—for example, a clock, random-value source, status client, or delay/concurrency boundary. Name it by the domain responsibility it expresses rather than by a mocking library.

Sketch the production call site and one focused test in C# or clear pseudocode. Your test must state its controlled input, action, expected observable result, and why it would have been unreliable, slow, or awkward before the change.

Complete this trade-off record:

| Decision | Your answer |
|---|---|
| Behaviour and risk | |
| Smallest production change | |
| New control or observation | |
| Cost/indirection introduced | |
| Evidence still needed with a real dependency | |
| Evidence that would justify merging the change | |

This is a design exercise. If you implement a short spike, use a temporary branch and discard it after the debrief; do not permanently fix course behaviour.

## Things to Investigate

- Can a framework or .NET type provide the seam without a custom abstraction?
- Is the dependency genuinely variable from the behaviour's perspective?
- Does the test assert a domain result rather than implementation calls?
- Could logging or a clearer result type solve part of the diagnosis problem?
- What do a real database, real HTTP boundary, and contract check still prove?

## Evidence

Show the risk statement, before/after dependency path, seam sketch, focused test, completed trade-off record, and a named real-dependency check that remains necessary.

## Stretch Challenge

Offer a lower-indirection alternative and define the evidence threshold at which the more elaborate seam would earn its cost.

## Hints

1. One seam for one behaviour is enough.
2. Inject a meaningful capability, not a bag of values used only by tests.
3. Deterministic unit evidence and realistic integration evidence answer different questions.

## Discussion

- Did the seam expose domain intent or merely add an interface?
- Which test became faster or more diagnostic?
- What could still fail when the controlled test passes?

