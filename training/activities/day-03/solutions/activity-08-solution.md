# Activity 8 — Trainer Solution: NeuroPulse Under Load

## Worked interpretation framework

Risk question:

> Under the supplied five-sample local telemetry workload, does Performance Stress
> change acceptance errors or response latency enough to justify a larger controlled
> experiment?

Run exactly the documented baseline and comparison into separate paths. Fill this table
from JMeter output; trainer notes must not invent benchmark values:

| Signal | Normal baseline | Performance Stress | Supported interpretation |
| --- | ---: | ---: | --- |
| Samples | measured | measured | Confirm comparable workload. |
| Errors / error % | measured | measured | Interpret every latency/throughput result alongside this. |
| Throughput | measured | measured | Affected by plan pacing, latency, and failures. |
| Average / median | measured | measured | Central tendency only. |
| p95 / p99 | measured | measured | With five samples these are effectively individual extremes, not stable tail estimates. |

The Performance Stress preset makes the telemetry path delay when the simulator config
reports High Volume. A slower comparison is consistent with that induced condition,
but five local samples do not establish production capacity, an SLO, causality outside
this controlled change, or a stable percentile distribution. A fast error can even
lower reported latency while worsening service quality.

## Classification, limitations, and next experiment

The supplied run is a tiny bounded **load comparison**, not stress (finding a breaking
point), spike (sudden step), or endurance (sustained duration) evidence. Limitations
include sample size, shared host contention, development configuration, absent resource
metrics, one request mix, no warm-up analysis, and an unspecified performance objective.

Next, repeat enough independent runs to check measurement stability while recording API,
database, container CPU/memory, and error signals; then vary only one agreed workload
factor. Do not increase load until the local target and stop conditions are explicit.
A credible future objective must name request mix/concurrency, environment, duration,
latency percentile, throughput, and error threshold, all agreed with stakeholders.

Restore Normal, verify training configuration, and remove `.jtl`/report directories
before committing.
