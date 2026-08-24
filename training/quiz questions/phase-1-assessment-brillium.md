# Phase 1 assessment — Brillium question bank

**Questions:** 10  
**Recommended assessment time limit:** 15 minutes  
**Recommended pass mark:** 70%  
**Question type:** Single-answer multiple choice

## Question 1

**Time limit:** 60 seconds  
**Question:** A team is discussing the NeuroPulse Start Recording rules before implementation. Which SDET contribution is most valuable?

- A. Wait for the completed UI and automate every path
- **B. Clarify boundaries and propose the cheapest useful feedback at each relevant level**
- C. Require all checks to be end-to-end
- D. Take sole ownership of release quality

**Correct answer:** B  
**Rationale:** An SDET helps prevent ambiguity and selects risk-appropriate feedback rather than merely automating later.

## Question 2

**Time limit:** 75 seconds  
**Question:** Which test provides the fastest diagnostic feedback that battery level 9% violates a minimum-10% recording rule?

- A. A full browser journey through every screen
- **B. A focused service or API rule test**
- C. A visual regression test
- D. An endurance test

**Correct answer:** B  
**Rationale:** The rule can be exercised faithfully below the UI, with faster and more isolated feedback.

## Question 3

**Time limit:** 60 seconds  
**Question:** Which Playwright locator is most resilient for a visible button labelled “Start recording”?

- A. `page.locator('div.actions > button:nth-child(2)')`
- B. `page.locator('.green')`
- **C. `page.getByRole('button', { name: 'Start recording' })`**
- D. `page.locator('[style*="green"]')`

**Correct answer:** C  
**Rationale:** A role locator with accessible name expresses user intent and avoids incidental structure or styling.

## Question 4

**Time limit:** 75 seconds  
**Question:** A Playwright test sometimes fails because telemetry appears between 0.5 and 2 seconds after recording starts. What is the best first change?

- A. Add `waitForTimeout(5000)`
- B. Retry the complete test ten times
- **C. Wait on a meaningful UI or network condition using a web-first assertion**
- D. Remove the telemetry assertion

**Correct answer:** C  
**Rationale:** Synchronize with observable readiness rather than guessing an elapsed duration or hiding the signal.

## Question 5

**Time limit:** 60 seconds  
**Question:** Which design best preserves test independence?

- A. Test B uses the participant created by Test A
- B. All tests mutate one shared recording session
- **C. Each test establishes the state it requires and does not depend on execution order**
- D. The suite runs only with one worker

**Correct answer:** C  
**Rationale:** Independent tests own their preconditions and remain valid in isolation or any order.

## Question 6

**Time limit:** 60 seconds  
**Question:** A `POST` request successfully creates a recording resource. Which status is the most semantically appropriate?

- A. 200 only, because all success is identical
- **B. 201 Created**
- C. 404 Not Found
- D. 500 Internal Server Error

**Correct answer:** B  
**Rationale:** HTTP semantics are part of the API contract; 201 communicates successful resource creation.

## Question 7

**Time limit:** 75 seconds  
**Question:** The NeuroPulse UI prevents submitting battery level -1. What gives the strongest evidence that the system protects the rule?

- A. The disabled button has the correct colour
- B. The UI displays a validation message
- **C. A direct API request with -1 is rejected and no invalid state is persisted**
- D. A GET request returns 200

**Correct answer:** C  
**Rationale:** The client can be bypassed, so server rejection and unchanged state establish protection at the trust boundary.

## Question 8

**Time limit:** 75 seconds  
**Question:** Which set best tests a valid battery range of 0–100 inclusive?

- A. 25, 50, 75
- **B. -1, 0, 1, 99, 100, 101**
- C. 0 and 100 only
- D. Three random valid values

**Correct answer:** B  
**Rationale:** It samples immediately below, at, and above both boundaries.

## Question 9

**Time limit:** 75 seconds  
**Question:** An API negative test receives the expected 400 response. What additional check is most valuable?

- A. The JSON is pretty-printed
- B. The test ran after a UI test
- **C. The error contract is meaningful and invalid data was not persisted**
- D. The response contains as many fields as possible

**Correct answer:** C  
**Rationale:** Status alone does not prove a useful response or absence of an unwanted side effect.

## Question 10

**Time limit:** 90 seconds  
**Question:** AI proposes ten tests for device assignment. What is the most responsible next step?

- A. Add all ten directly to CI
- B. Trust them because they are syntactically valid
- C. Reject AI for all testing work
- **D. Review them against requirements, risks, architecture, duplication, and actual system behaviour**

**Correct answer:** D  
**Rationale:** AI suggestions are hypotheses that need human evaluation and evidence; generated volume is not confidence.

