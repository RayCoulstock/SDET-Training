# Activity 5 — AI as Pair Tester

**Day:** 3  
**Activity:** 5  
**Related slides:** AI as Pair Tester—not Autopilot  
**Suggested time:** 10 minutes

## Objective

Use AI to structure a failure investigation while retaining responsibility for evidence, API accuracy, and the final decision.

## Before You Start

Use only a course- or workplace-approved AI tool. Remove credentials, personal data, internal URLs, and unnecessary repository content. If no approved tool is available, exchange evidence packs with another pair and let them act as the assistant.

## Your Task

Prepare a bounded evidence pack from Activity 4 or the fixed wait in `navigation.spec.ts`. Include the test purpose, relevant code, exact failure or concern, and a short timeline. Exclude your preferred solution.

Ask for:

1. ranked causal hypotheses;
2. evidence for and against each;
3. the next discriminating diagnostic action; and
4. the smallest safe change if a cause is established.

Review every claim. Classify it as **supported**, **needs verification**, **irrelevant**, or **incorrect**. Verify any suggested Playwright API against the installed package/type definitions or by running a minimal safe check. Compare the ranking with your own and record what, if anything, improved the investigation.

## Things to Investigate

- Did the response distinguish a symptom from a cause?
- Did it invent repository state or test APIs?
- What evidence would falsify its highest-ranked hypothesis?
- Did a confident tone influence your assessment?
- Is the proposed refactor smaller and safer than the original problem?

## Evidence

Keep the sanitised prompt, response classification, one verified claim, one rejected claim, and your independently owned next action.

## Stretch Challenge

Revise the prompt to request a hypothesis table rather than a code fix. Compare the usefulness of the two responses.

## Hints

1. Better evidence is usually more valuable than a longer prompt.
2. Ask what observation would disprove a hypothesis.
3. Generated code must pass the same review and execution checks as human code.

## Discussion

- Where did AI add structure rather than certainty?
- Which unsupported claim was most plausible?
- What remains the engineer's responsibility?
