# Activity 3 — Trainer Solution: Coach the Developer

## Example coaching card: Start Recording control

| Element | Notes |
| --- | --- |
| Neutral observation/evidence | ParticipantDetail renders Start Recording as a clickable `div` with an id containing a random number; it has no native button role. |
| User/developer risk | Keyboard/assistive-technology users may not be able to identify or operate it, and automation cannot use the intended button-role locator. Random ids also destabilise selectors. |
| Unknown | Whether a release accessibility criterion exists, whether styling depends on `div`, and the release/change budget. |
| Curious questions | “How is this interaction expected to work without a pointer?” “Is anything relying on the generated id or element type?” |
| Smallest option | Render a native `button type="button"` while preserving the class/visual style; verify keyboard, role/name, click, and disabled behaviour. |
| Alternative/trade-off | Add role, tabindex, and keyboard handlers temporarily, but this recreates native semantics and is easier to get wrong. A test id aids automation only and does not resolve access. |
| Verification | Keyboard-only exploration, accessibility-tree/role inspection, one semantic Playwright check, and existing start-flow regression. |

## Example conversation outcome

With a “release tomorrow; no visual redesign” constraint, agree that the developer owns
a short native-button spike preserving `.start-action` styling today. The SDET pairs on
keyboard/role and recording smoke evidence. If the spike exposes compatibility risk,
the team records a named follow-up with owner and date rather than silently accepting it.

Constructive review wording:

> I noticed this control only handles a pointer click, so keyboard users and our
> role-based test cannot operate it. Is there a compatibility reason it cannot be a
> native button? Could we try that minimal substitution and compare keyboard, styling,
> and the focused recording check before deciding?

For the fixed-wait example, replace “This is flaky” with: “This test always waits three
seconds, while the outcome we need is the Participants heading. Have we seen evidence
that elapsed time represents readiness? Could we compare repeated duration/failure
traces using the web-first heading assertion?” Coaching maintains the quality standard
while making constraints, ownership, and evidence shared.
