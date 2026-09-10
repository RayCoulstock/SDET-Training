# Activity 1 — What Makes This Difficult to Test?

**Day:** 4  
**Activity:** 1  
**Related slides:** Testability Is a Design Property; A NeuroPulse Dependency Map  
**Suggested time:** 15 minutes

## Objective

Analyse one production service for controllability, observability, determinism, isolation, and replaceability, then rank the resulting risks.

## Before You Start

Read `src/NeuroPulse.Api/Services/SessionService.cs`, `src/NeuroPulse.Api/Program.cs`, and the recording-session story in `docs/user-stories.md`. Review only; do not refactor the service yet.

## Scenario

The team wants fast feedback for recording rules while retaining confidence in PostgreSQL and the Device Simulator integration. “Add unit tests” is not yet an actionable plan because the important dependencies and risks have not been separated.

## Your Task

Draw the dependency path from `SessionService.Start` and `Stop` to persistence, HTTP, time, randomness, and delay. For each dependency, complete:

| Dependency or outcome | How it enters the behaviour | Controllable? | Observable? | Deterministic? | Failure risk | Candidate test level |
|---|---|---|---|---|---|---|

Include the session eligibility rules and saved result as outcomes, not only technical dependencies. Mark facts from code separately from assumptions about intended behaviour.

Rank the **two constraints that most damage useful feedback**. Explain the test or diagnosis each makes difficult and the consequence for a developer. Do not assume every concrete dependency needs an interface or every database interaction needs a mock.

## Things to Investigate

- Which collaborators are supplied to the service, and which inputs are obtained directly?
- Can a test choose an exact `StartedAt`, `EndedAt`, signal, or quality value?
- Which rules can be exercised before the simulator call, and which require it?
- What can a returned error reveal? What useful context is missing?
- Would replacing PostgreSQL prove EF mapping, constraints, or query behaviour?
- Does a controllable dependency automatically make a test isolated?

## Evidence

Bring the dependency map, the completed table, two ranked constraints with reasons, and one dependency you would deliberately keep real in an appropriate test.

## Stretch Challenge

Place three proposed checks across a small portfolio—fast rule test, database integration test, and consumer/provider or integrated check—and state the distinct failure each should localise.

## Hints

1. Look for `DateTime.UtcNow`, `Random.Shared`, `Task.Delay`, `HttpClient`, and `AppDbContext`.
2. Testability is a characteristic of a behaviour, not a count of interfaces.
3. A real dependency may reduce control while adding evidence a double cannot provide.

## Discussion

- Which constraint was most important rather than merely easiest to notice?
- Where would extra observability be more valuable than substitution?
- Which confidence would be lost if every dependency were replaced?

