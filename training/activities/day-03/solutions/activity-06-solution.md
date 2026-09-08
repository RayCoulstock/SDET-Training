# Activity 6 — Trainer Solution: What Does NeuroPulse Actually Depend On?

## Interaction map

NeuroPulse.Api is the **consumer** and Device Simulator is the **provider**.

| Contract element | Consumer use | Required? | Why |
| --- | --- | --- | --- |
| Provider state | Serial exists and is available in V1 | Yes | Gives provider verification a reproducible starting state. |
| Method/path | `GET /api/devices/NP-1001/status` | Yes | This is the actual request made using the assigned device serial. |
| Status | `200` | Yes | JSON cannot be used when the dependency rejects the request. |
| `connected` boolean | Eligibility decision | Yes | `false` rejects start. |
| `deviceId` string | Deserialised but not used in the decision | Debatable/minimise | Include only if deserialisation/identity validation is an intended consumer requirement. Current code does not compare it. |
| `battery` integer | Deserialised but not used; stored device battery drives threshold | No for this decision | Requiring an exact value adds coupling without protecting current behaviour. |

## Minimal contract sketch

```text
Given device NP-1001 is connected using the V1 representation
Upon receiving a request for device availability
With request GET /api/devices/NP-1001/status
Will respond with status 200, JSON content type, and a body containing
  connected: true
```

A consumer test uses the Pact mock to prove NeuroPulse sends the expected request and
can interpret the minimal response to continue its decision. Provider verification
replays that interaction against the real simulator state, proving it can honour the
consumer expectation. A mock alone can merely repeat a mistaken assumption; provider
unit tests alone can prove V2 internally correct while missing V1 consumers.

Neither check proves deployed networking/configuration, PostgreSQL behaviour, all
eligibility rules, UI accessibility, or a complete recording journey. One selected
integration check remains useful. A disconnected provider state can add
`connected: false` without matching irrelevant exact battery values.
