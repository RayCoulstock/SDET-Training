# Activity 2 — Trainer Solution: Make the Behaviour Testable

## Chosen risk and current path

> A session stopped at a reporting boundary can receive an unrepeatable `EndedAt`, so
> exact timestamp behaviour cannot be tested without race-prone before/after ranges.

Current path: `Stop(id)` → read Recording session → `DateTime.UtcNow` → save → return.

## Smallest seam

Use the framework `TimeProvider`, injected with `TimeProvider.System` in production:

```csharp
public class SessionService(AppDbContext db, HttpClient devices, TimeProvider time)
{
    public async Task<(RecordingSession? Session, string? Error)> Stop(int id)
    {
        var session = await db.Sessions.FindAsync(id);
        if (session is null) return (null, "Session does not exist.");
        if (session.Status != SessionStatus.Recording)
            return (null, "Only a recording session may be stopped.");

        session.Status = SessionStatus.Completed;
        session.EndedAt = time.GetUtcNow().UtcDateTime;
        await db.SaveChangesAsync();
        return (session, null);
    }
}
```

Register `TimeProvider.System` once. A focused test uses a fake provider fixed at
`2030-03-31T00:00:00Z`, stores a Recording session, calls `Stop`, and asserts Completed
plus exactly that `EndedAt` in both returned and persisted state. Previously the test
could only assert a time window and could fail around scheduling or boundary instants.

## Trade-off record

| Decision | Answer |
| --- | --- |
| Behaviour and risk | Exact stop timestamp is part of saved session evidence and must be deterministic at boundaries. |
| Smallest production change | Inject framework `TimeProvider`; replace one direct UTC read. |
| New control/observation | Test selects an exact instant and observes domain/persisted result. |
| Cost/indirection | Constructor/DI dependency and a concept contributors must understand. |
| Real evidence still needed | PostgreSQL mapping/UTC representation and API serialisation through `POST /sessions/{id}/stop`. |
| Merge evidence | Focused test fails on old direct time, passes with seam; existing integration checks pass; production registration is verified. |

A lower-indirection alternative is a before/after range assertion, suitable if exact
boundary behaviour has little risk. The seam earns its cost when multiple time-based
rules, recurring flakes, or reporting boundaries need exact control. It does not replace
database, HTTP, or end-to-end evidence.
