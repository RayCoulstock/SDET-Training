# Day 1 Activities — From QA Engineer to SDET

These activities accompany **Phase 1 — Day 1** of the NeuroPulse SDET programme. Work in pairs where the trainer asks you to, and keep brief notes: the class debriefs depend on the evidence and decisions you collect rather than on everyone reaching one answer.

| Activity | Topic | Suggested Time | Main Skill |
| -------- | ----- | -------------- | ---------- |
| [1 — Quality Across the SDLC](activity-01-quality-across-the-sdlc.md) | Quality interventions throughout a feature's lifecycle | 20 minutes | Risk prevention and shared ownership |
| [2 — Where Should This Test Live?](activity-02-where-should-this-test-live.md) | Choosing useful test levels | 20 minutes | Test placement and trade-offs |
| [3 — Your First NeuroPulse Test](activity-03-your-first-neuropulse-test.md) | A focused browser check | 25 minutes | Playwright fundamentals |
| [4 — Find the Most Resilient Locator](activity-04-find-the-most-resilient-locator.md) | Semantic, maintainable selectors | 15 minutes | Locator evaluation |
| [5 — Why Is This Test Flaky?](activity-05-why-is-this-test-flaky.md) | Synchronisation and meaningful conditions | 15 minutes | Reliable asynchronous testing |
| [6 — Investigate a Failed Test](activity-06-investigate-a-failed-test.md) | Evidence-led failure analysis | 10 minutes | Diagnosis and hypothesis building |

**Total planned practical activity time:** approximately **105 minutes**.

Trainer worked examples and debrief notes are available in the
[`solutions`](solutions/README.md) folder. They are intended as reference answers rather
than a single marking scheme; several activities deliberately allow more than one
well-supported conclusion.

## Working Safely with the Training State

The application is shared teaching material for later activities. Unless an activity says otherwise, use the **Normal** training scenario and avoid changing application code. If the data no longer looks familiar, ask before resetting it: a reset affects every test using the same environment.

When you change a starter test, use a short-lived Git branch or keep a copy of the original. Preserve useful evidence, then discard experimental test changes at the end of Day 1 unless your trainer asks you to commit them.
