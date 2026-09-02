# Day 3 Activities — Engineering an Automation Strategy

These activities accompany **Phase 2 — Day 1** of the NeuroPulse SDET programme. They move from individual checks to maintainable suites, then examine reliability, service contracts, and performance evidence.

| Activity | Topic | Suggested Time | Main Skill |
| -------- | ----- | -------------- | ---------- |
| [1 — Review the Growing NeuroPulse Suite](activity-01-review-the-growing-suite.md) | Suite growth and maintenance risks | 15 minutes | Prioritised test-suite review |
| [2 — Remove the Repeated Setup](activity-02-remove-the-repeated-setup.md) | Fixtures and API-assisted state | 15 minutes | Isolated setup design |
| [3 — Should This Become a Page Object?](activity-03-should-this-become-a-page-object.md) | Useful automation abstractions | 10 minutes | Trade-off analysis |
| [4 — Find the Source of the Flake](activity-04-find-the-source-of-the-flake.md) | Intermittent failures | 15 minutes | Evidence-led diagnosis |
| [5 — AI as Pair Tester](activity-05-ai-as-pair-tester.md) | AI-assisted failure analysis | 10 minutes | Hypothesis evaluation |
| [6 — What Does NeuroPulse Actually Depend On?](activity-06-what-does-neuropulse-depend-on.md) | Consumer contracts | 10 minutes | Boundary modelling |
| [7 — Catch the Breaking Change](activity-07-catch-the-breaking-change.md) | Provider compatibility | 10 minutes | Contract-risk investigation |
| [8 — How Does NeuroPulse Behave Under Load?](activity-08-neuropulse-under-load.md) | JMeter and performance signals | 15 minutes | Controlled performance interpretation |

**Total planned practical activity time:** approximately **100 minutes**.

## Working Safely

Start from the course `README.md` and use a short-lived branch for test experiments. NeuroPulse uses shared, persistent training data and Playwright runs fully in parallel. A global reset or simulator scenario change can affect another test or learner, so coordinate before using `/training` or `POST /api/training/reset`.

Return the simulator to **Normal** after activities that change it. Keep JMeter at the activity's bounded classroom load; this is a local learning exercise, not permission to load-test any other environment. Use only fictional data, and share no secrets or sensitive data with an AI tool.
