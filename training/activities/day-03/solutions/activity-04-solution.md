# Activity 4 — Trainer Solution: Find the Source of the Flake

## Worked fixed-wait investigation

Concern: the navigation test sleeps for three seconds before checking a heading. This
is a reliability and speed risk even if the current local run always passes.

| Rank | Category | Hypothesis | Distinguishing evidence |
| --- | --- | --- | --- |
| 1 | Timing | The fixed delay guesses when route rendering is complete | Trace shows heading became available well before 3s, or a throttled run takes longer and still fails. |
| 2 | Environment/dependency | Application startup or proxy availability delays/fails navigation | Network/console and service health show failed document/API request rather than merely slow UI state. |
| 3 | State/data | Shared reset changes participant data | Weak for this test because it asserts only the static heading/navigation; list-readiness tests would be exposed. |
| 4 | Concurrency | Another worker disrupts the shared environment | Correlate failure time with reset/scenario logs or run serially as a diagnostic comparison. |

## Reproduction and conclusion

Run the original several times with trace retained, then copy it temporarily and remove
only `waitForTimeout`. Replace the guessed delay with:

```ts
await page.getByRole('link', { name: 'Participants' }).click();
await expect(page.getByRole('heading', { name: 'Participants' })).toBeVisible();
```

Compare trace timelines and durations. If both pass and the web-first assertion waits
for the route outcome, evidence supports removing the unconditional wait; it does not
prove that every historical failure shared that cause. The heading proves navigation,
not participant data completion.

The next discriminating experiment for a remaining failure is to capture the failed
document/API response and application console alongside the trace, not raise the
timeout. A larger timeout wastes fast runs and cannot repair a 503, bad selector,
shared-state collision, or provider incompatibility. Retries should retain the first
failure and must not redefine intermittent behaviour as acceptable.

For the alternative Unreliable Device path, classify a simulator 503 as expected
dependency behaviour under that preset; the defect question is whether NeuroPulse
handles and explains it appropriately. Restore Normal and record the direct V1 status.
