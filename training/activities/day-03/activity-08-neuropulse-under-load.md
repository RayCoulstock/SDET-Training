# Activity 8 — How Does NeuroPulse Behave Under Load?

**Day:** 3  
**Activity:** 8  
**Related slides:** Functional Correctness Is Not Enough; Load, Stress, Spike, Endurance; Why the Average Can Lie; JMeter: Small Mental Model  
**Suggested time:** 15 minutes

## Objective

Compare a controlled telemetry baseline with one bounded change and interpret latency, throughput, percentiles, and errors without making an unsupported benchmark claim.

## Before You Start

Make sure NeuroPulse and JMeter are available. Read `tests/performance/jmeter/README.md`. Coordinate scenario controls, begin in **Normal**, and keep all load on your local training environment.

## Your Task

State a narrow risk question and record the environment, workload, and expected signal. From `tests/performance/jmeter`, run the safe baseline:

```bash
jmeter -n -t telemetry-smoke.jmx -l baseline.jtl -e -o baseline-report
```

Record sample count, errors, throughput, average, median, p95, and p99 latency. Note why five observations cannot support a stable tail-latency claim.

Choose **one** controlled comparison:

- apply **Performance Stress** and rerun the same workload; or
- copy the plan, raise concurrency only to a trainer-agreed classroom value, and keep Normal.

Write results to different `.jtl` and report paths. Compare like with like, then state the strongest conclusion the evidence supports, at least two limitations, and the next safe experiment. Restore **Normal** and do not commit generated results.

## Things to Investigate

- Is this load, stress, spike, or endurance testing—and why?
- Did throughput change because of workload, latency, errors, or all three?
- Can a fast failed response improve latency while harming quality?
- Why might p95 and p99 be unstable with this sample size?
- Which application, database, or host metrics would strengthen diagnosis?

## Evidence

Show the risk question, two named result sets, a comparison of key signals, limitations, next experiment, and confirmation that Normal was restored.

## Stretch Challenge

Propose a credible performance objective containing workload, environment, threshold, and duration. Label every assumption needing stakeholder agreement.

## Hints

1. Use a new output directory each time; JMeter will not overwrite a populated report directory.
2. An error rate belongs beside every latency interpretation.
3. A controlled comparison changes one factor and records everything else that could matter.

## Discussion

- What did the comparison establish, and what did it not establish?
- Which percentile would you communicate, with what caveat?
- What would you monitor before increasing the load?
