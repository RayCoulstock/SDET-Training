# Activity 4 — The UI Said No; What Does the API Say?

**Day:** 2  
**Activity:** 4  
**Related slides:** UI Validation ≠ System Protection; Debrief — Validation Has Layers  
**Suggested time:** 15 minutes

## Objective

Compare client-side constraints with direct API behaviour and decide which system layer must protect each rule.

## Before You Start

Make sure NeuroPulse is running. Open the **Add Participant** form in the UI and the supplied **Create participant** request in Postman. Use fictional, distinctive values.

## Your Task

1. Submit one valid participant through the UI and observe the form's input constraints and visible result.
2. Choose one email or required-field variation that the browser form does not accept normally. Record what the UI prevents or reports.
3. Reproduce the valid payload in Postman, then apply the same variation and send it directly to the API.
4. Record status, body, and any persisted result. If necessary, use a list or search request to check the resulting state.
5. For the rule you explored, assign responsibility across **UI**, **API**, **domain/service**, and **database**. State what each relevant layer should prove without demanding identical implementations.

Do not include the behaviour you expect to find in advance; let the evidence answer the question.

## Things to Investigate

- What does browser validation improve for an ordinary user?
- Which clients can bypass the React form?
- What is the authoritative trust boundary for this input?
- Is acceptance, rejection, or the quality of the error the main risk?
- How will you distinguish what was displayed from what was stored?

## Evidence

Show the UI observation, direct request and response, persisted-state check, and a short layer-responsibility map.

## Stretch Challenge

Propose a compact coverage portfolio for this rule: one fast check below the UI and one UI check with a distinct accessibility or guidance purpose.

## Hints

1. Browser developer tools can show constraints on the selected input without changing application code.
2. Start from the collection's valid payload and alter only the chosen field.
3. A `2xx` status and a displayed row are different pieces of evidence.

## Discussion

- Which layer should prevent an untrusted client from violating the rule?
- Would copying the same test through every layer improve confidence?
- How would you report a mismatch without overclaiming its impact?
