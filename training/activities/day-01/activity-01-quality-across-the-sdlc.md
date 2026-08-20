# Activity 1 — Quality Across the SDLC

**Day:** 1  
**Activity:** 1  
**Related slides:** Quality Across the SDLC  
**Suggested time:** 20 minutes

## Objective

Identify opportunities to prevent, detect, and diagnose risk throughout a feature's lifecycle, and make ownership explicit.

## Scenario

NeuroPulse is changing **Start Recording**. A recording may start only when:

- the participant is active;
- the device is assigned to that participant;
- the device is connected;
- its battery is at least 10%; and
- the device has no active recording.

The change will move from an idea through design, implementation, build, release, and operation. Your team wants confidence without leaving all quality work until the feature reaches a tester.

## Your Task

In a small group, draw the feature's path through the SDLC. At each stage, propose one or two **specific** quality interventions. Label each intervention as mainly:

- prevention;
- detection; or
- diagnosis.

For each intervention, name who should participate and what feedback or artefact it produces. Avoid writing “test it” without explaining the risk, signal, and timing.

## Things to Investigate

- Which rule or assumption should be clarified before code exists?
- Where would an example at exactly 10% battery be most useful?
- Which collaborators or system boundaries affect the result?
- What could a code review, build pipeline, or pre-release check reveal?
- What evidence would help after release when a technician reports that starting failed?
- Which intervention provides the fastest useful feedback? Which provides the most realistic confidence?

## Evidence

Be ready to show:

- your lifecycle map;
- at least one prevention, detection, and diagnosis intervention;
- an owner or collaborators for each intervention; and
- one risk that still requires observation after release.

## Stretch Challenge

A product owner proposes changing the threshold from “at least 10%” to “more than 10%”. Mark every place on your map where that apparently small change should create work or feedback.

## Hints

1. Start with the question each stage should answer, not with a tool name.
2. Consider product examples, architecture, code, automated feedback, deployment controls, and operational signals.
3. Shared ownership is useful only when the contribution at each point is clear.

## Discussion

- Where could the team prevent the most expensive failure?
- Which feedback arrives fastest, and what can it not prove?
- Where does an SDET add specialist value without becoming the sole owner of quality?
