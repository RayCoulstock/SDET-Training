# Activity 4 — Trainer Solution: The UI Said No

## Example: malformed email

The Add Participant form uses a required `type="email"` input. A value such as
`not-an-email` is stopped by browser constraint validation and no request should be
sent. This improves immediate guidance, but Postman is not constrained by the form.

A direct `POST /api/participants` with the same string currently reaches the endpoint.
The endpoint constructs and saves a participant without explicit email validation, so
an otherwise bindable payload may receive `201 Created` and be visible in a later list
or search. Trainers should have learners record their actual response and persisted
state rather than reveal the result before the experiment.

## Responsibility map

| Layer | Appropriate responsibility and evidence |
| --- | --- |
| UI | Provide an email-specific control, required indication, accessible feedback, and prevent ordinary accidental submission. One browser check proves guidance and focus/message behaviour. |
| API boundary | Reject missing, malformed, or unbindable untrusted input with a stable status and useful representation. This is the authoritative remote-client boundary. |
| Domain/service | Preserve any agreed participant invariant independently of which endpoint/client invoked it; normalise only if product rules say so. |
| Database | Enforce storage integrity that must survive every writer (for example nullability or uniqueness if agreed), but should not be the sole source of user guidance. |

The repository story does not define email syntax or uniqueness, so acceptance by the
API demonstrates a mismatch with browser constraints, not automatically a confirmed
story defect. Raise a bounded product question: “Must every participant email satisfy
the browser's email syntax for all clients, and should it be unique?”

## Compact portfolio

Use an API/domain test matrix for required/malformed input and persistence, plus one UI
check that verifies accessible error guidance and that no request is sent. Copying the
whole matrix through the browser adds cost without protecting the trust boundary. In a
report, separate facts (`201`; record returned by search) from impact, whose severity
depends on the product decision.
