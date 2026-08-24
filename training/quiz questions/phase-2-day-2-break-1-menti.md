# Phase 2 — Day 2 — Tea break 1 Menti

1. **What does it mean for testability to be a design property?**
   - A. Tests can always be added without design changes
   - **B. The system makes important behaviour controllable and observable**
   - C. Every method is public
   - D. Only the UI is tested
   - Feedback: Design choices determine how easily tests can control inputs and observe outcomes.

2. **Why should time be injected behind a clock abstraction?**
   - A. To make production clocks more accurate
   - **B. To let tests control time deterministically**
   - C. To avoid timestamp assertions entirely
   - D. To make tests run at midnight
   - Feedback: Controllable time removes dependence on the wall clock.

3. **Why can uncontrolled randomness make a test unreliable?**
   - A. Random values are never valid
   - **B. Failures may be hard to reproduce because the inputs change**
   - C. Randomness prevents compilation
   - D. It only affects performance tests
   - Feedback: Injecting or seeding randomness makes behaviour repeatable.

4. **What is a test seam?**
   - A. A duplicate assertion
   - **B. A place where a dependency or behaviour can be substituted or controlled**
   - C. A hidden production defect
   - D. A mandatory mock for every class
   - Feedback: Seams enable focused testing, but each abstraction has a cost.

5. **How should a test isolate an unreliable external device service?**
   - A. Add a longer fixed sleep
   - **B. Substitute a controlled implementation at an intentional boundary**
   - C. Remove all integration tests
   - D. Depend on the real service for every test
   - Feedback: A controlled seam supports deterministic focused tests while separate integration checks cover wiring.

