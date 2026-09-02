# Activity 3 — Coach the Developer

**Day:** 4  
**Activity:** 3  
**Related slides:** Gatekeeper or Quality Coach?  
**Suggested time:** 15 minutes

## Objective

Turn a genuine NeuroPulse quality concern into an evidence-led coaching conversation that builds shared ownership and offers proportionate options.

## Scenario

A developer is preparing a release and believes the current implementation is adequate. You have noticed one concern, but you do not yet know their constraints or whether your preferred change is the smallest useful response.

## Your Task

In pairs, choose one repository example:

- the Start Recording interaction in `src/neuropulse-web/src/main.tsx`;
- the fixed wait in `tests/playwright/tests/navigation.spec.ts`;
- the recording error shown by `ParticipantDetail`; or
- one direct dependency in `SessionService`.

Prepare a coaching card:

| Element | Notes |
|---|---|
| Neutral observation and evidence | |
| User/developer risk | |
| What you do not yet know | |
| Two curious questions | |
| Smallest option | |
| Alternative and trade-off | |
| How the team could verify improvement | |

Role-play a four-minute conversation. The reviewer should first establish shared intent and ask about constraints. The developer should introduce one realistic constraint, such as release timing, accessibility scope, test runtime, compatibility, or limited refactoring budget. Agree a next action and evidence—not necessarily the reviewer's original solution. Swap roles using a different concern if time permits.

Avoid labels such as “bad code”, appeals to best practice without impact, or treating the SDET as the sole owner of approval.

## Things to Investigate

- What does the repository demonstrate rather than what do you assume?
- Who experiences the consequence, and under which condition?
- Is the concern must-fix now, follow-up work, or a question?
- Can an experiment resolve disagreement more cheaply than debate?
- How can you maintain a serious standard without becoming a gatekeeper?

## Evidence

Bring the coaching card, the developer constraint, the agreed action and owner, and the evidence that will show whether it helped.

## Stretch Challenge

Rewrite a blunt comment—“This is flaky; replace it with a proper wait”—as a concise observation, question, and suggested experiment.

## Hints

1. Lead with a specific condition and consequence.
2. Ask before prescribing; there may be context absent from the code.
3. “We will investigate” needs an owner, evidence, and decision point.

## Discussion

- Which question changed the proposed response?
- How did the constraint affect priority without erasing the risk?
- What distinguishes collaborative coaching from lowering the bar?

