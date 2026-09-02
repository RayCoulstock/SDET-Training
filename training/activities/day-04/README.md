# Day 4 Activities — The SDET as a Quality Advocate

These activities accompany **Phase 2 — Day 2** of the NeuroPulse SDET programme. They move from analysing testability and proposing a proportionate seam to coaching, risk-focused review, structured exploration, and assessment evidence planning.

| Activity | Topic | Suggested Time | Main Skill |
| -------- | ----- | -------------- | ---------- |
| [1 — What Makes This Difficult to Test?](activity-01-what-makes-this-difficult-to-test.md) | Testability and dependency analysis | 15 minutes | Risk-ranked design review |
| [2 — Make the Behaviour Testable](activity-02-make-the-behaviour-testable.md) | Test seams and determinism | 20 minutes | Proportionate seam design |
| [3 — Coach the Developer](activity-03-coach-the-developer.md) | Shared quality ownership | 15 minutes | Constructive technical coaching |
| [4 — Review This Pull Request](activity-04-review-this-pull-request.md) | Quality-focused code review | 15 minutes | Prioritised evidence-based feedback |
| [5 — Explore an Unreliable NeuroPulse Device](activity-05-explore-an-unreliable-device.md) | Exploratory testing | 25 minutes | Charter-led investigation |
| [6 — Phase 2 Assessment Preparation](activity-06-phase-2-assessment-preparation.md) | Integrated evidence planning | 10 minutes | Capability and decision mapping |

**Total planned practical activity time:** approximately **100 minutes**.

## Working Safely

Use a short-lived branch for any optional code experiments. Activities 1–4 are reviews and design exercises: do not permanently repair NeuroPulse or commit a speculative refactor. If you do create a spike, keep the change small and discard it after preserving your evidence.

NeuroPulse training data and simulator configuration may be shared. Coordinate before changing `/training` or calling the reset endpoint. Activity 5 starts from **Normal**, temporarily uses **Unreliable Device** or **Exploratory Testing**, and must finish by restoring **Normal**. A data reset affects every learner using the environment.

Use only fictional course data. Do not put credentials, personal information, internal URLs, or confidential source into review notes or AI tools.

