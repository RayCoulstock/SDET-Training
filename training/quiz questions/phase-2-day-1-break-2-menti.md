# Phase 2 — Day 1 — Tea break 2 Menti

1. **A flaky test is best treated as what?**
   - A. Proof that retries should be unlimited
   - **B. A symptom requiring evidence and diagnosis**
   - C. A reason to add an arbitrary sleep
   - D. An acceptable random failure
   - Feedback: Investigate state, timing, dependencies, and observations rather than masking failure.

2. **What is the safest use of AI when analysing a failed test?**
   - A. Merge its first fix without review
   - **B. Use it to generate hypotheses, then verify them against traces, logs, and code**
   - C. Paste secrets so it has more context
   - D. Ask it to weaken the assertion
   - Feedback: AI can accelerate reasoning but evidence must decide.

3. **In contract testing, who defines the interaction it needs?**
   - A. The database
   - **B. The consumer**
   - C. The load generator
   - D. The browser vendor
   - Feedback: The consumer captures its expectation and the provider verifies it.

4. **Which change is most likely to break a consumer contract?**
   - A. Adding an optional response field
   - **B. Renaming a required response field without coordination**
   - C. Improving internal logging
   - D. Refactoring an unexposed private method
   - Feedback: Changing required shape can make an existing consumer unable to parse the response.

5. **What does provider verification establish?**
   - A. The UI has no visual defects
   - **B. The provider satisfies the recorded consumer interactions**
   - C. The service has infinite capacity
   - D. Every possible request has been tested
   - Feedback: Verification gives focused compatibility confidence, not exhaustive correctness.

