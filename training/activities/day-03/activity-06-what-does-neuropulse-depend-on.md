# Activity 6 — What Does NeuroPulse Actually Depend On?

**Day:** 3  
**Activity:** 6  
**Related slides:** The Contract Problem; Consumer Contract + Provider Verification  
**Suggested time:** 10 minutes

## Objective

Identify the smallest meaningful consumer expectation at the NeuroPulse API–Device Simulator boundary.

## Before You Start

Read `docs/architecture.md` and `tests/contracts/README.md`. Inspect the simulator status route and the call made by `src/NeuroPulse.Api/Services/SessionService.cs`; do not switch contract versions yet.

## Your Task

Map the interaction:

| Contract element | Consumer use | Required for this behaviour? | Why? |
|---|---|---|---|
| Provider state | | | |
| Method and path | | | |
| Response status | | | |
| Response fields/types | | | |
| Values or matching rules | | | |

Focus on starting a recording when an assigned device is available. Draft a consumer interaction in plain English or Pact-style pseudocode with **given**, **upon receiving**, **with request**, and **will respond with**. Include only fields the consumer reads for this decision.

Explain what a consumer test with a mock would prove, what provider verification adds, and what neither proves about the complete NeuroPulse journey.

## Things to Investigate

- Which service is the consumer and which is the provider?
- What exact path and representation does the consumer deserialize?
- Is a particular battery value part of compatibility, or is its type enough?
- Would specifying every provider field make the contract safer or more brittle?
- Why is an integrated test alone late feedback for independent deployment?

## Evidence

Show the interaction map, minimal contract sketch, and the distinct evidence supplied by consumer testing, provider verification, and integration testing.

## Stretch Challenge

Add a second provider state without duplicating irrelevant response detail.

## Hints

1. Contract scope comes from observed consumer use, not the provider's entire schema.
2. A mock that only repeats the consumer's assumptions does not verify the real provider.
3. “No more” is as important as “enough” in a maintainable contract.

## Discussion

- Which response elements did you exclude?
- Where should the contract be verified in a delivery pipeline?
- What risk remains after provider verification passes?
