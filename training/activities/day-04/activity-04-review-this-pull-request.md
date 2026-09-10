# Activity 4 — Review This Pull Request

**Day:** 4  
**Activity:** 4  
**Related slides:** Quality-Focused Code Review  
**Suggested time:** 15 minutes

## Objective

Write concise, prioritised review comments about behaviour and risk rather than producing an unranked list of style preferences.

## Before You Start

Treat the current implementations of `SessionService.Start` in `src/NeuroPulse.Api/Services/SessionService.cs` and the `start` function in `ParticipantDetail` in `src/neuropulse-web/src/main.tsx` as the review packet. Use the recording-session story in `docs/user-stories.md` as acceptance context. Do not edit the files.

## Scenario

The pull request introduces the recording-start flow from the browser through the API to the Device Simulator. The author says the happy path works. Your review should help the team decide whether the change is safe enough to merge and what can reasonably follow later.

## Your Task

Review for:

- observable outcomes and diagnostic failures;
- controllable dependencies and appropriate test levels;
- hidden state or representation assumptions;
- repetition and concurrency;
- preservation of recording-session invariants; and
- accessible, automatable user interaction.

Create a findings table before writing comments:

| Evidence (file/behaviour) | Trigger | Potential impact | Confidence | Priority | Suggested verification |
|---|---|---|---|---|---|

Choose at most **three** findings. Label each **must address**, **should address**, **question**, or **optional**. Write the exact review comment you would post, including:

1. the observed code or behaviour;
2. the condition and potential impact;
3. a question that checks missing context; and
4. a proportionate suggestion or experiment.

End with a review summary that clearly distinguishes merge-critical evidence from follow-up improvement. Do not demand a framework, a Page Object, or complete test coverage without explaining the risk it addresses.

## Things to Investigate

- What happens when two starts overlap or a dependency fails?
- Which validation belongs to the domain service rather than the browser?
- Does the browser preserve useful API error detail for diagnosis?
- Can users and Playwright identify and operate the control semantically?
- Which finding is evidenced, and which is only a plausible concern?

## Evidence

Bring the findings table, no more than three ready-to-post comments, and the review summary with a justified merge position.

## Stretch Challenge

For the highest-priority comment, propose the smallest automated or manual experiment that could disprove your concern.

## Hints

1. Read the user story before judging implementation choices.
2. A line reference is evidence of implementation, not yet evidence of impact.
3. One high-signal comment is more useful than ten unprioritised observations.

## Discussion

- Which comment could change the merge decision, and why?
- Where did a question work better than a prescription?
- Which concern belongs in follow-up work rather than this pull request?

