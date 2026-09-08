# Activity 2 — Trainer Solution: Remove the Repeated Setup

## Chosen outcome: reject an inactive participant

| Proposed preparation | Classification | Decision |
| --- | --- | --- |
| Open Participants and create a participant through the form | State setup | Create through API unless form creation is the behaviour under test. |
| Locate a device through the UI | State setup | Use an explicit API/fixture result; browsing is irrelevant. |
| Assign a device | State setup/precondition | Establish directly and return both ids; do not hide eligibility state. |
| Navigate to participant detail | Behaviour setup | Retain because the browser rejection presentation is under test. |
| Operate Start Recording and inspect feedback | Behaviour under test | Retain. |

## Fixture sketch

```ts
import { test as base, expect, APIRequestContext } from '@playwright/test';

type RecordingState = {
  participantId: number;
  deviceId: number;
  participantName: string;
};

async function createInactiveRecordingState(
  request: APIRequestContext,
  unique: string,
): Promise<RecordingState> {
  const participantResponse = await request.post('/api/participants', { data: {
    firstName: 'Training', lastName: unique,
    email: `training.${unique}@example.test`, dateOfBirth: '1990-01-01',
    status: 'Inactive',
  }});
  expect(participantResponse.status()).toBe(201);
  const participant = await participantResponse.json();

  const deviceResponse = await request.post('/api/devices', { data: {
    serialNumber: `AUTO-${unique}`, model: 'NeuroBand X',
    firmwareVersion: '1.4.2', batteryPercentage: 80,
    connectionStatus: 'Connected',
  }});
  expect(deviceResponse.status()).toBe(201);
  const device = await deviceResponse.json();
  await expect(await request.post(`/api/devices/${device.id}/assign`, {
    data: { participantId: participant.id },
  })).toBeOK();
  return { participantId: participant.id, deviceId: device.id,
    participantName: `Training ${unique}` };
}
```

Use a test-scoped helper/fixture and a collision-resistant value containing worker
index, retry index, and a random UUID. The helper owns the created participant and
device and returns their identifiers rather than making the UI rediscover them.

## Lifetime and limitation

The API has no delete endpoints, so true teardown is unavailable. Unique append-only
data avoids collisions but grows the database and does not isolate a class-wide reset.
Use a disposable environment/database in CI and reset between coordinated runs, never
inside fully parallel tests. A simulator status request for an arbitrary newly created
serial returns a fallback response that is not connected, but inactivity is checked
before the simulator call, so that dependency is irrelevant to this rejection outcome.

A plain helper keeps setup visible and is sufficient here. Promote it to a fixture if
many tests need lifecycle hooks or typed automatic context; convenience must not hide
which eligibility condition the test controls.
