# Activity 2 — Explore the NeuroPulse API

**Day:** 2  
**Activity:** 2  
**Related slides:** Postman: Investigation Workspace  
**Suggested time:** 15 minutes

## Objective

Use the supplied Postman assets to investigate a NeuroPulse resource systematically and describe its HTTP behaviour.

## Before You Start

Make sure NeuroPulse is running. Import `postman/NeuroPulse.postman_collection.json` and `postman/NeuroPulse.local.postman_environment.json`, then select the local environment.

## Your Task

Send **List participants** once to verify the environment. In a pair, choose **Participants**, **Devices**, or **Sessions** and investigate one list request.

1. Record the baseline method, resolved URL, status, response content type, elapsed time, and JSON shape.
2. Use `docs/api-reference.md` or Swagger at `http://localhost:5000/swagger` to find the supported filters for that resource.
3. Duplicate and clearly rename the request. Add one meaningful filter value.
4. Predict how the response should change, send the request, and compare the evidence with your prediction.
5. Write one small Postman response assertion that checks a stable property, such as the status or response content type. Do not assert the exact duration or the complete seeded response.

## Things to Investigate

- Is the JSON response an object or an array, and how can you tell?
- Does the status alone prove that the filter behaved correctly?
- Which observations describe the HTTP contract, and which depend on seed data?
- How could a well-named saved request help another tester reproduce your finding?

## Evidence

Show the baseline and filtered requests, the before/after observations, the result of your response assertion, and one unanswered question about the resource.

## Stretch Challenge

Request a resource identifier that does not exist. Compare the status, headers, and response body with the successful list response.

## Hints

1. Postman shows the resolved URL in the console if a variable is unclear.
2. Filters belong in the **Params** table; let Postman encode them.
3. A useful assertion checks intended behaviour without duplicating the entire response.

## Discussion

- What did Postman make easier than browser-only investigation?
- Which assertion would remain useful if the seed records changed?
- What would you automate outside Postman, and why?
