# Phase 1 — Day 1 — Tea break 2 Menti

1. **What is a Playwright locator?**
   - A. A stored DOM element
   - **B. A live recipe for finding an element**
   - C. A screenshot coordinate
   - D. An arbitrary delay
   - Feedback: Locators resolve against the current page when used.

2. **Which locator usually expresses user intent most clearly?**
   - A. `page.locator('div:nth-child(3)')`
   - B. `page.locator('.blue-button')`
   - **C. `page.getByRole('button', { name: 'Start recording' })`**
   - D. `page.locator('#btn-17')`
   - Feedback: Role and accessible name tend to be meaningful and resilient.

3. **Why prefer a web-first assertion such as `toBeVisible()`?**
   - A. It disables asynchronous behaviour
   - **B. It retries until the condition succeeds or times out**
   - C. It always waits exactly five seconds
   - D. It prevents all application defects
   - Feedback: Web-first assertions synchronize with eventual browser state.

4. **What is the main problem with `waitForTimeout(3000)`?**
   - A. It cannot be used in TypeScript
   - B. It changes the application data
   - **C. It waits for elapsed time rather than meaningful readiness**
   - D. It makes selectors inaccessible
   - Feedback: Fixed sleeps can be both unnecessarily slow and still too short.

5. **What makes a browser test independent?**
   - A. It runs alphabetically before other tests
   - B. It reuses state created by a previous test
   - **C. It creates or controls the state it needs and cleans up appropriately**
   - D. It has more than one assertion
   - Feedback: Independent tests do not rely on suite order or leaked state.

