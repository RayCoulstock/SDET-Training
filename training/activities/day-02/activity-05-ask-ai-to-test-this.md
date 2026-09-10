# Activity 5 — Ask AI to Test This

**Day:** 2  
**Activity:** 5  
**Related slides:** AI-Enabled Testing: Useful Roles; The Risk Ledger  
**Suggested time:** 20 minutes

## Objective

Use AI as an idea generator, compare its suggestions with human test design, and verify rather than trust its output.

## Before You Start

Use only an AI tool approved for the course or workplace. Share no personal, customer, credential, proprietary, or production data. If no approved tool is available, one person can role-play the assistant by producing plausible ideas from the same prompt.

Choose either **Start a recording session** or **Assign a device** from `docs/user-stories.md`. Do not inspect instructor-only documentation.

## Your Task

### 1. Design before prompting

Individually write your three highest-value test ideas and list any ambiguous requirement. Include the risk and expected evidence for each idea.

### 2. Ask for candidates

Give the AI only the selected user-story text and ask for test ideas. Save the exact prompt and response. Mark every claim the response makes about NeuroPulse routes, data, or behaviour.

### 3. Evaluate

Classify each useful-looking suggestion as **keep**, **adapt**, **duplicate**, **unsupported**, or **low value**. Verify factual claims against `docs/api-reference.md`, Swagger, or observed behaviour. Do not execute generated code merely because it looks plausible.

### 4. Improve the prompt

Create a second prompt that adds relevant constraints: known HTTP surface, boundary information, desired test level, evidence required, and an instruction to label assumptions. Compare the second result with the first and with your original ideas.

## Things to Investigate

- Did the model invent requirements or endpoints?
- Did more ideas mean better risk coverage?
- Which human idea was missing, and which AI idea genuinely broadened the design?
- Did the improved prompt reduce unsupported certainty?
- What still requires a product decision or executed test?

## Evidence

Bring your original ideas, both prompts and outputs, the classification, at least two verified claims, and one recommendation you would defend.

## Stretch Challenge

Ask the AI to rank the retained ideas by risk and feedback speed. Challenge one ranking with your own reasoning.

## Hints

1. Ask for assumptions in a separate column.
2. Context should be relevant and minimal, not a repository dump.
3. Verification means checking a primary repository source or running a safe investigation.

## Discussion

- Where did AI accelerate the work, and where did it create review work?
- Which suggestion survived verification?
- Who owns the final test decision and its consequences?
