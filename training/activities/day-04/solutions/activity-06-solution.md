# Activity 6 — Trainer Solution: Phase 2 Assessment Preparation

## Example cross-boundary risk

When the simulator reports an assigned device unavailable, NeuroPulse must not persist
a Recording session and should provide diagnosable, usable feedback through API and UI.

| Capability | Decision to defend | Proportionate evidence | Limitation/trade-off | Team quality question |
| --- | --- | --- | --- | --- |
| Risk analysis/test level | Put eligibility matrix at service level; select HTTP/provider and one UI path | Risk map and distinct claims per level | Controlled doubles do not prove deployment | Which status source is authoritative? |
| Maintainable automation | Fixture owns unique participant/device ids; semantic action and web-first outcome | Focused Playwright code, parallel/repeat result, trace | API has no delete route | Can CI provide disposable databases? |
| API/contract investigation | V1 `connected` expectation is verified against provider | Consumer interaction, provider verification, direct/integrated evidence | Does not prove whole journey | How will V1 evolve independently? |
| Performance reasoning | Bound provider latency/failure risk before broader load | Small controlled workload with percentiles/errors and environment record | Small local sample is not capacity evidence | What latency/error objective matters to technicians? |
| Testability improvement | Control simulator status through a domain-named status client | Before/after path and focused result assertion | Additional seam/DI; real HTTP still needed | Does the seam improve diagnosis enough to maintain? |
| Exploratory/risk communication | Examine failure, repetition, and recovery across two boundaries | Charter, timestamped notes, bounded report, uncertainty | Timebox estimates rather than prevalence | What recovery should the user initiate? |

## Evidence order and marked decisions

1. **Verify assumption:** story and product owner clarify stored versus live connection
   authority and expected failure category.
2. Exercise fast controlled rule examples; **decision point:** if the service can save
   after a provider failure, stop and prioritise the invariant before browser work.
3. Verify the minimal consumer contract, retaining the **real simulator** in provider
   verification and one integrated check.
4. Add PostgreSQL side-effect/concurrency evidence, then one semantic UI rejection path.
5. Explore recovery; only then plan a bounded performance comparison if latency remains
   material.

**Honest limitation:** local controlled evidence cannot establish production failure
frequency or capacity. **Collaboration:** the SDET brings the authority/error question
to product and pairs with the developer on the smallest status-client experiment; the
team owns the decision.

A 60-second showcase should state the risk, explain why contract plus persistence
evidence is strongest, admit the production-frequency gap, and name the next owner/
decision. Remove screenshots or counts that do not change that decision. Peer review
might, for example, remove a duplicate UI rule matrix and retain one accessibility-
specific journey.
