# JMeter telemetry starter
Start NeuroPulse, then run `jmeter -n -t telemetry-smoke.jmx -l results.jtl`. The plan sends a safe five telemetry writes to historical session 1. Increase threads gradually during class and select **Performance Stress** to expose bounded artificial/database latency.
