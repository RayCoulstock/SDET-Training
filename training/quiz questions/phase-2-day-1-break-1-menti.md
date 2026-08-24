# Phase 2 — Day 1 — Tea break 1 Menti

1. **What is a strong reason to use API-assisted setup for a UI test?**
   - A. It proves every setup screen works
   - **B. It creates required state faster and with less UI coupling**
   - C. It removes the need for assertions
   - D. It makes tests share state
   - Feedback: Keep the UI journey focused on the risk under test.

2. **A fixture should make which concern explicit?**
   - A. The colour of every button
   - **B. Ownership and lifetime of reusable test context**
   - C. The order in which all tests run
   - D. A mandatory fixed delay
   - Feedback: Good fixtures clarify setup, scope, and cleanup.

3. **What is the clearest warning sign of a poorly scoped Page Object?**
   - A. It uses TypeScript
   - B. It represents a coherent page capability
   - **C. It becomes a large dumping ground that hides assertions and business intent**
   - D. It exposes meaningful actions
   - Feedback: Page Objects are useful abstractions, not a compulsory home for all test logic.

4. **What should setup and teardown optimize for?**
   - A. Maximum dependence between tests
   - **B. Deterministic, isolated tests with understandable state**
   - C. The largest possible UI journey
   - D. Fewer diagnostics
   - Feedback: State control is part of test design.

5. **When should repeated code become a shared abstraction?**
   - A. After the first repeated line, always
   - B. Only when a style guide demands it
   - **C. When the abstraction represents a stable, meaningful capability**
   - D. Never in tests
   - Feedback: Avoid both needless duplication and premature abstraction.

