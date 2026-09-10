# Activity 2 — Trainer Solution: Explore the NeuroPulse API

## Worked Participants investigation

| Observation | Baseline | Filtered example |
| --- | --- | --- |
| Method and URL | `GET http://localhost:5000/api/participants` | `GET http://localhost:5000/api/participants?status=Inactive` |
| Expected status | `200` | `200` |
| Content type | JSON | JSON |
| Body shape | Array of participant objects | Array of participant objects |
| Prediction | All current participants | Only records whose status is `Inactive` |

The exact elapsed time, array length, and identifiers are observations from that run,
not portable contract assertions. Under freshly reset Normal data the inactive filter
includes Noah Williams and Leo Evans, but a trainer should accept a different count
after legitimate shared-state changes.

## Small Postman test

```js
pm.test('returns a JSON participant collection', function () {
  pm.response.to.have.status(200);
  pm.expect(pm.response.headers.get('Content-Type')).to.include('application/json');
  pm.expect(pm.response.json()).to.be.an('array');
});

pm.test('respects the requested inactive status', function () {
  pm.response.json().forEach((participant) => {
    pm.expect(participant.status).to.eql('Inactive');
  });
});
```

The second assertion passes vacuously for an empty list, so during investigation also
record whether the chosen data should contain a match. A separately controlled test
could create its own participant before asserting presence.

## Stretch and unanswered question

`GET /api/participants/999999` should produce `404`, unlike the successful list's
`200` and array body. The current minimal endpoint may return an empty response body;
record that rather than inventing a problem-details contract.

A useful open question is whether search is contractually case-insensitive. The
implementation can be observed, but the short API reference alone does not specify
all matching semantics. Save requests as, for example, `Participants — inactive only`
so the intent and reproduction input survive beyond the session.
