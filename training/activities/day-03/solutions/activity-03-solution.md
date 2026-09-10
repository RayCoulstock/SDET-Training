# Activity 3 — Trainer Solution: Should This Become a Page Object?

## Example decisions

| Candidate | Repeated knowledge/problem | Approach | Benefit | Cost/warning |
| --- | --- | --- | --- | --- |
| Primary navigation | Same accessible link selection and destination confirmation | Small component object or helper once genuinely repeated | Centralises shared shell semantics without owning whole pages | A full Page Object would add ceremony for one click. |
| Participant search/status filters | Coupled controls and rendered result region | `ParticipantsPage` with task methods, if several checks use it | Names filtering intent and absorbs locator/copy changes | Do not put seeded assertions or participant creation inside it. |
| Recording workflow and preconditions | API-created state plus detail-page action | Test-scoped fixture for state + small participant-detail component/page method | Keeps ownership separate from user interaction | A “recording page” that resets data, assigns devices, clicks, and asserts everything becomes a god object. |

Keeping a one-off navigation step inline is also defensible; three lines are not by
themselves an abstraction problem.

## Interface sketch

```ts
export class ParticipantsPage {
  constructor(private readonly page: Page) {}

  async open(): Promise<void>;
  async filterByText(term: string): Promise<void>;
  async filterByStatus(status: 'Active' | 'Inactive' | 'All'): Promise<void>;
  participantLink(name: string): Locator;
}
```

The object performs interactions and exposes a meaningful result locator; the test
keeps its own expected names and assertions. It does not create database records,
reset global state, or contain unrelated device/session workflows.

Changing search from immediate input to an explicit Search button could be absorbed
inside `filterByText`. Changing the business expectation from substring matching to
prefix matching must still change test cases and assertions—that knowledge should not
be hidden. Introduce the object only when repeated interaction knowledge or coordinated
UI change demonstrates the benefit; periodically delete methods no longer used.
