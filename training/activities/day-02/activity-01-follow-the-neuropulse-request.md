# Activity 1 — Follow the NeuroPulse Request

**Day:** 2  
**Activity:** 1  
**Related slides:** HTTP for Testers; Status Codes Are Part of the Behaviour  
**Suggested time:** 15 minutes

## Objective

Connect one visible browser behaviour to the HTTP request and response that support it.

## Before You Start

Make sure NeuroPulse is running in the **Normal** scenario. Open the browser developer tools, select **Network**, and clear any existing entries.

## Your Task

Open **Participants** and search for part of a participant's name or email. In the Network panel, locate the request caused by the search. If your browser sends several requests while you type, identify the response that produced the final visible list.

Record:

- the browser action and visible outcome;
- request method and URL, including query parameters;
- request headers that help explain the exchange;
- response status, relevant headers, and body shape;
- one relationship between a JSON field and what the page displays.

Classify each observation as **transport**, **representation**, or **business behaviour**. Then propose one focused API check and one UI check. The checks should provide different evidence.

## Things to Investigate

- What proves that you selected the request associated with the final search term?
- Which browser details are incidental, and which are part of the behaviour worth testing?
- Could a `200` response still produce an incorrect user outcome?
- What can the network evidence explain if the page shows no results?

## Evidence

Be ready to show the selected Network entry, a concise request/response description, your classification, and the two complementary check ideas.

## Stretch Challenge

Repeat the trace using a status filter. Compare its query parameter and response data with the free-text search.

## Hints

1. Filter Network entries by `participants` or by **Fetch/XHR**.
2. Inspect **Headers**, **Payload**, **Response**, and **Timing** rather than relying on the request name alone.
3. The UI calls routes beginning with `/api`; the browser's address bar remains on the page route.

## Discussion

- Which piece of evidence most strongly connects the response to the rendered result?
- What could an API-level check isolate more quickly?
- What important behaviour would still require a browser-level check?
