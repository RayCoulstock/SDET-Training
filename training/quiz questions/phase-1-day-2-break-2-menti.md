# Phase 1 — Day 2 — Tea break 2 Menti

1. **For a minimum valid battery level of 10%, which values best exercise the boundary?**
   - A. 1%, 50%, and 99%
   - **B. 9%, 10%, and 11%**
   - C. 10%, 20%, and 30%
   - D. Only 10%
   - Feedback: Values immediately below, at, and above a boundary are informative.

2. **What is a negative API test designed to explore?**
   - A. Only successful happy paths
   - **B. Invalid, missing, conflicting, or unauthorized input and resulting behaviour**
   - C. Browser colours
   - D. CPU load only
   - Feedback: Negative tests examine how the service rejects or handles unacceptable requests.

3. **Why is client-side validation insufficient on its own?**
   - A. Browsers cannot display errors
   - B. JSON bypasses HTTP
   - **C. Clients can be bypassed, so the API must protect its own rules**
   - D. API validation is always faster to write
   - Feedback: Each trust boundary must enforce the rules for which it is responsible.

4. **The UI blocks an invalid value. What is the best next investigation?**
   - A. Assume the whole system is protected
   - **B. Send the invalid request directly to the API and inspect its response and state**
   - C. Add a five-second browser wait
   - D. Change the CSS selector
   - Feedback: Direct API testing determines whether server-side validation exists.

5. **A good API assertion checks more than the status code. What else may matter?**
   - A. Only response time
   - B. Only JSON indentation
   - **C. Response body, headers, and resulting persisted state**
   - D. The test file name
   - Feedback: A plausible status can still hide an incorrect contract or side effect.

