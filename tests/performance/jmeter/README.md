# JMeter telemetry starter

The plan sends a safe five telemetry writes to historical session 1. Keep the scenario set to **Normal** for the baseline.

## Recommended: included Docker setup

From the repository root, run:

```bash
rm -rf tests/performance/jmeter/results/baseline.jtl \
       tests/performance/jmeter/results/baseline-report
docker compose --profile tools run --rm jmeter
```

Compose builds the pinned JMeter 5.6.3 image, starts NeuroPulse if necessary, waits for the API to become healthy, and connects to the API over the Compose network. Results are written to `results/baseline.jtl` and `results/baseline-report/`. Generated results are ignored by Git.

JMeter refuses to replace a non-empty report directory, which is why the cleanup command is explicit. Give every comparison a different file and directory by overriding the service command, for example:

```bash
docker compose --profile tools run --rm jmeter \
  -n -t /plans/telemetry-smoke.jmx -Jhost=api -Jport=8080 \
  -l /results/stress.jtl -e -o /results/stress-report
```

## Existing host installation

If JMeter is already installed, start NeuroPulse and run this from the current directory:

```bash
jmeter -n -t telemetry-smoke.jmx -l baseline.jtl -e -o baseline-report
```

The plan defaults to `localhost:5000` for host execution. Its `host` and `port` JMeter properties allow the same plan to work in Docker without maintaining a second copy.

Increase threads only to a trainer-agreed value during class, and select **Performance Stress** only for the bounded comparison. Restore **Normal** afterwards.
