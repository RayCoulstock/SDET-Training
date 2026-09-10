# Activity 4 — Trainer Solution: Review This Pull Request

## Findings table

| Evidence | Trigger | Potential impact | Confidence | Priority | Verification |
| --- | --- | --- | --- | --- | --- |
| `AnyAsync` occurs before delay/save with no visible unique invariant | Two concurrent starts for one device | Duplicate active recordings violate the story | High as risk; occurrence needs experiment | Must address | Barrier-synchronised requests plus PostgreSQL row count/constraint inspection |
| UI catches every error and displays only `Something went wrong.` | Any domain/provider rejection | Technician cannot distinguish correctable state; support loses diagnosis | High | Should address | Force inactive, battery, and simulator failures; compare API and visible messages |
| Start action is random-id clickable `div` | Keyboard/assistive tech or stable automation | Interaction unavailable/non-semantic; brittle tests | High | Must address | Keyboard and accessibility-tree check; role-based Playwright locator |

## Ready-to-post comments

**Must address — concurrency invariant**

> `Start` checks for an active row and then waits/saves in separate operations. If two
> requests overlap, both can observe no active recording and create one, violating the
> story's device invariant. Is there a database constraint or transaction not visible
> here? Please add a barrier-synchronised PostgreSQL test; if it reproduces, protect the
> invariant atomically rather than relying only on the pre-check.

**Must address — operable control**

> The Start Recording action is a click-only `div` whose id changes on render. Under
> keyboard or assistive-technology use it has no button semantics, and a stable
> intent-based locator cannot find it. Is any consumer dependent on this markup? The
> smallest experiment is a native button preserving the CSS, followed by keyboard,
> accessible-name, and focused start-flow checks.

**Should address — diagnostic feedback**

> The API returns distinct eligibility/provider errors, but `catch` discards all of
> them as “Something went wrong.” When a battery, assignment, or simulator check fails,
> the technician cannot correct the state and support cannot distinguish causes. Which
> details are safe and intended for users? Could we map agreed user messages while
> logging structured cause/correlation data, then exercise two rejection paths?

## Review summary

Request changes until the team has evidence that duplicate starts are prevented and
the primary action is operable semantically; both concern story invariants/user access.
Precise error wording can follow only with an owned decision if current release scope
cannot settle it, but preserving diagnostic cause needs an explicit plan. Randomness,
time seams, and broader refactoring are valuable follow-ups, not blanket merge demands.
