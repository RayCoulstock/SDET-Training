# Day 2 Activities — Testing Beyond the User Interface

These activities accompany **Phase 1 — Day 2** of the NeuroPulse SDET programme. Keep a short record of requests, responses, assumptions, and decisions: the debriefs focus on evidence and reasoning rather than the number of requests sent.

| Activity | Topic | Suggested Time | Main Skill |
| -------- | ----- | -------------- | ---------- |
| [1 — Follow the NeuroPulse Request](activity-01-follow-the-neuropulse-request.md) | Browser actions and HTTP traffic | 15 minutes | Evidence-led request tracing |
| [2 — Explore the NeuroPulse API](activity-02-explore-the-neuropulse-api.md) | Postman and API resources | 15 minutes | Structured API investigation |
| [3 — Break the API](activity-03-break-the-api.md) | Negative and boundary testing | 20 minutes | Risk-based test design |
| [4 — The UI Said No; What Does the API Say?](activity-04-the-ui-said-no.md) | Validation at different layers | 15 minutes | Trust-boundary analysis |
| [5 — Ask AI to Test This](activity-05-ask-ai-to-test-this.md) | AI-assisted test design | 20 minutes | Prompting and critical evaluation |
| [6 — Would You Merge This AI-Generated Test?](activity-06-would-you-merge-this-ai-generated-test.md) | Reviewing generated tests | 15 minutes | Test-code review |
| [7 — Phase 1 Assessment Preparation](activity-07-phase-1-assessment-preparation.md) | Evidence planning | 10 minutes | Capability and evidence mapping |

**Total planned practical activity time:** approximately **110 minutes**.

## Working Safely with the Training State

Start the application with the course `README.md` instructions and keep the simulator on **Normal** unless the trainer says otherwise. Import both files from `postman/` and select the local environment so `baseUrl` resolves to `http://localhost:5000`.

Several activities send requests that can change shared data. Coordinate with your partner, use distinctive synthetic values, and reset only at an agreed point:

```bash
curl -X POST http://localhost:5000/api/training/reset
```

A reset affects everyone using that environment. Do not use real personal, customer, health, or company-confidential data in Postman or an AI tool.
