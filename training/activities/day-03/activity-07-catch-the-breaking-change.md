# Activity 7 — Catch the Breaking Change

**Day:** 3  
**Activity:** 7  
**Related slides:** V1 → V2: Compatible or Breaking?  
**Suggested time:** 10 minutes

## Objective

Predict and expose a provider change that is valid in isolation but incompatible with NeuroPulse's consumer expectations.

## Before You Start

Preserve the contract sketch from Activity 6. Coordinate scenario changes, and begin with the simulator in **Normal** (V1).

## Your Task

1. Call `GET http://localhost:5100/api/devices/NP-1001/status` and record the V1 status and JSON shape.
2. Predict which elements of your consumer contract would fail if field names or connection representation changed. State the expected consumer symptom.
3. Apply **Contract Breaking Change** at `http://localhost:3000/training`.
4. Repeat the direct provider request and compare the representation with your prediction.
5. Exercise Start Recording through NeuroPulse or send the equivalent API request. Capture response and service evidence.
6. Explain where a consumer contract and provider verification should have detected the incompatibility before integrated deployment.
7. Return the scenario to **Normal** and confirm the provider is back on V1.

Do not repair the application. Focus on compatibility evidence and a safe migration conversation.

## Things to Investigate

- Can both V1 and V2 be internally valid provider designs?
- Which failure belongs to transport, deserialisation, or business interpretation?
- Would provider unit tests alone protect the consumer?
- Could additive evolution or dual-version support reduce deployment coupling?
- What evidence confirms environment restoration?

## Evidence

Show the V1/V2 comparison, predicted contract failures, observed consumer symptom, proposed pre-deployment detection point, and restored V1 response.

## Stretch Challenge

Sketch a coordinated migration sequence that allows consumer and provider teams to deploy independently.

## Hints

1. Compare property names and value representations, not only HTTP status.
2. The direct simulator response and NeuroPulse API response describe different boundaries.
3. Re-run the V1 provider request after restoring Normal.

## Discussion

- Where was the earliest useful place to fail?
- Why can provider correctness coexist with consumer breakage?
- What contract detail gave the clearest compatibility signal?
