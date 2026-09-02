# Activity 3 — Break the API

**Day:** 2  
**Activity:** 3  
**Related slides:** Positive Is the Beginning; Boundary Thinking: Battery Level  
**Suggested time:** 20 minutes

## Objective

Design and execute a small, risk-based set of negative and boundary API checks with explicit expected outcomes.

## Before You Start

Use the running **Normal** environment and the supplied Postman collection. Work from a successful request before changing it. Avoid the Training routes and simulator scenario controls.

## Your Task

Choose one request family:

- create a participant;
- create or assign a device;
- start a recording session; or
- submit telemetry.

Write a mini test charter stating the risk you will investigate. Select **three to five** variations from at least two categories: missing or null data, malformed representation, a just-below/at/just-above boundary, invalid identity or state, or a repeated request.

Before sending each request, record:

| Variation | Why it matters | Expected status/outcome | Evidence observed | Conclusion or question |
|---|---|---|---|---|

Vary one relevant assumption at a time where possible. Inspect the status, response headers and body, and any resulting resource—not only whether Postman labels the request successful.

Do not treat surprising behaviour automatically as a defect. Compare it with `docs/user-stories.md` and distinguish a violated stated rule from an ambiguous or missing requirement.

## Things to Investigate

- Is this input validation, a business invariant, or both?
- Are domain edges different from business-rule boundaries?
- Does a failure response explain what the caller can correct?
- Did the request create or change state despite its response?
- Which combination has the greatest risk, rather than merely being unusual?

## Evidence

Bring your charter, completed table, saved request variants, and one prioritised finding or product question to the debrief.

## Stretch Challenge

Add one combination of conditions and explain why pairwise changes make diagnosis harder than changing one variable.

## Hints

1. The Start Recording story states the expected participant, device, battery, connection, and active-session conditions.
2. Swagger shows request shapes, but a schema is not a complete statement of business intent.
3. Preserve the original successful request so you can retest your baseline.

## Discussion

- Which negative case provided the most useful information?
- Where did the requirement support a firm expected result?
- Which observation should become a regression check, and at what test level?
