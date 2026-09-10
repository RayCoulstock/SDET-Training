# Activity 7 — Trainer Solution: Catch the Breaking Change

## Expected comparison

For `NP-1001`, Normal V1 returns a successful JSON response shaped like:

```json
{"deviceId":"NP-1001","connected":true,"battery":87}
```

Contract Breaking Change returns a successful but incompatible V2 shape:

```json
{"id":"NP-1001","status":"ONLINE","batteryPercent":87}
```

Record actual casing/content from the running service. Both can be internally coherent
provider representations; `200` does not make V2 compatible with a V1 consumer.

## Prediction and observed boundary

The consumer deserialises V1 into `DeviceStatus(deviceId, connected, battery)` and reads
`Connected`. Renaming the field and changing a boolean to `"ONLINE"`/`"OFFLINE"`
violates the minimal expectation. Depending on .NET constructor binding behaviour, the
NeuroPulse call may fail deserialisation and return `400` with a status-validation error,
or produce an unusable/default value and reject as unavailable. Capture the actual API
body and service evidence; do not assert a single symptom without executing it.

This is representation/deserialisation or interpretation failure, not transport
failure: the direct provider request can remain `200`.

## Earliest detection and migration

Publish the consumer Pact from NeuroPulse CI and verify it in simulator CI before V2
deployment. Provider unit tests alone do not include the consumer expectation. A safe
migration can add V2 fields while retaining V1, deploy a tolerant/dual-version consumer,
then remove V1 only after all consumers confirm migration.

Finish by applying Normal and calling the provider route again. Restoration evidence
is a V1 `200` containing boolean `connected`, not merely the Training screen label.
