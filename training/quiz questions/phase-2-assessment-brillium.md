# Phase 2 assessment — Brillium question bank

**Questions:** 10  
**Recommended assessment time limit:** 15 minutes  
**Recommended pass mark:** 70%  
**Question type:** Single-answer multiple choice

## Question 1

**Time limit:** 75 seconds  
**Question:** A UI test needs an assigned connected device before it checks the Start Recording journey. What is the best setup strategy?

- A. Depend on another UI test to assign it
- **B. Create the precise precondition through a controlled API or fixture**
- C. Click through every setup screen in every test
- D. Use whichever shared participant happens to exist

**Correct answer:** B  
**Rationale:** Controlled setup keeps the UI test focused, faster, and independent.

## Question 2

**Time limit:** 75 seconds  
**Question:** When is a Page Object most useful?

- A. Whenever two lines of code look similar
- B. As a home for all assertions and business rules
- **C. When it exposes a stable, coherent page capability and hides incidental interaction detail**
- D. When it mirrors every DOM element with a getter

**Correct answer:** C  
**Rationale:** The abstraction should preserve intent and reduce coupling, not conceal the test's purpose.

## Question 3

**Time limit:** 75 seconds  
**Question:** A test intermittently times out while waiting for device status. What is the best first diagnostic action?

- A. Triple every timeout
- B. Add unlimited retries
- **C. Inspect trace, network, logs, and state to identify what did or did not complete**
- D. Delete the failing assertion

**Correct answer:** C  
**Rationale:** Flakiness is a symptom; evidence should locate the timing, state, or dependency problem before a fix.

## Question 4

**Time limit:** 75 seconds  
**Question:** NeuroPulse consumes a Device Simulator response. What does a consumer contract primarily describe?

- A. Every behaviour the provider could ever support
- **B. The interactions and response shape the NeuroPulse consumer relies on**
- C. The provider's database schema
- D. Browser presentation rules

**Correct answer:** B  
**Rationale:** Consumer-driven contracts focus on the provider behaviour required by that consumer.

## Question 5

**Time limit:** 75 seconds  
**Question:** Which provider change is most likely to be breaking?

- A. Adding an optional diagnostic header
- B. Improving an internal algorithm without changing behaviour
- **C. Changing a required `connectionStatus` field to `status`**
- D. Adding an unused optional JSON property

**Correct answer:** C  
**Rationale:** Removing or renaming a field the consumer parses violates its expected shape.

## Question 6

**Time limit:** 75 seconds  
**Question:** A latency report has an average of 180 ms and a p95 of 1.8 s. What does p95 indicate?

- A. Every request completed in 1.8 s
- **B. About 95% completed at or below 1.8 s, while the slow tail may be worse**
- C. 95% of requests failed
- D. The average is invalid

**Correct answer:** B  
**Rationale:** Percentiles expose distribution and tail latency that an average can hide.

## Question 7

**Time limit:** 75 seconds  
**Question:** Which test evaluates behaviour under expected sustained usage?

- A. Stress test beyond capacity
- B. One functional API check
- **C. Load test at representative traffic**
- D. Contract verification

**Correct answer:** C  
**Rationale:** Load testing evaluates performance under an anticipated workload; stress seeks limits and failure behaviour.

## Question 8

**Time limit:** 75 seconds  
**Question:** A service decides expiry using `DateTime.UtcNow` directly. Which change most improves deterministic testability?

- A. Add a longer timeout
- **B. Inject a clock whose value tests can control**
- C. Make every private method public
- D. Run the test only at a fixed real-world time

**Correct answer:** B  
**Rationale:** Treating time as a dependency lets tests exercise boundaries repeatably.

## Question 9

**Time limit:** 75 seconds  
**Question:** Which statement best describes structured exploratory testing?

- A. Unplanned clicking without notes
- B. Executing a fixed script without adapting
- **C. Time-boxed learning guided by a charter, observations, and evolving hypotheses**
- D. A substitute for every automated check

**Correct answer:** C  
**Rationale:** Exploration is purposeful investigation in which learning influences the next action.

## Question 10

**Time limit:** 90 seconds  
**Question:** Which is the clearest quality-risk communication?

- A. “Telemetry is broken.”
- B. “Testing failed, so do not release.”
- **C. “In 4 of 10 disconnected-device trials, status stayed Connected for over 30 seconds; this may let technicians start invalid recordings. Trace links and reproduction conditions are attached.”**
- D. “I found four bugs.”

**Correct answer:** C  
**Rationale:** It combines evidence, conditions, frequency, user or business impact, and reproducible diagnostics without overstating certainty.

