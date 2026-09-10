# NeuroPulse

NeuroPulse is a fictional wearable-device management application and a testing laboratory for professional SDET training. It is not medical software. The deliberately compact architecture is intended to be understood in one sitting, while leaving substantial automation and investigation work for students.

> This training application may contain intentional behaviours designed for testing exercises.

Course facilitators can find the slide deck in [`training/slides`](training/slides/) and the tea-break Menti quizzes and end-of-phase Brillium question banks in [`training/quiz questions`](training/quiz%20questions/).

## Architecture and local services

| Service | URL | Purpose |
|---|---|---|
| React UI | http://localhost:3000 | Dashboard and workflows |
| NeuroPulse API | http://localhost:5000 | REST API; Swagger at `/swagger` |
| Device simulator | http://localhost:5100 | External-device boundary; Swagger at `/swagger` |
| PostgreSQL | localhost:5432 | Persistent training data |

The browser calls the ASP.NET Core API, which stores data through EF Core in PostgreSQL and consumes the independent device simulator. See [the architecture guide](docs/architecture.md), [domain model](docs/domain-model.md), and [API reference](docs/api-reference.md).

## Prerequisites and start

Install Docker Desktop (or Docker Engine with Compose v2), then run:

```bash
docker compose up --build
```

Schema creation and deterministic seed data are automatic. Open http://localhost:3000. The instructor controls are intentionally absent from navigation; access them directly at http://localhost:3000/training.

Before class, confirm that every application container is healthy and that the API responds:

```bash
docker compose ps
curl --fail http://localhost:5000/health
```

After pulling repository changes, use `up` rather than `start`: `start` only restarts the existing containers and does not rebuild the API image or apply changed Compose configuration.

The core PostgreSQL, simulator, API, and web definitions remain on the configuration from the last known-good application stack (`d484a91f1dc95bfd111f516f09852dd9798b8071`). The optional JMeter profile is additive and is not created during a normal `docker compose up`.

```bash
docker compose down
docker compose up --build --force-recreate
```

Stop with `docker compose down`; remove the database volume with `docker compose down -v`. Follow logs with `docker compose logs -f api device-simulator`.

## Resetting data

Use **Reset Training Data** at `/training`, or:

```bash
curl -X POST http://localhost:5000/api/training/reset
```

This recreates the fixed participants, devices, sessions, and telemetry. Scenario **Normal** resets behavioural controls.

## Testing tools

### Playwright

```bash
cd tests/playwright
npm install
npx playwright install chromium
npm test
```

The three starter examples use Chromium, an HTML report, failure screenshots, and retry traces. Set `BASE_URL` to target a different UI.

### Postman, Pact, and JMeter

Import both JSON files in `postman/`. The collection groups the primary endpoints and uses `baseUrl=http://localhost:5000`. Pact scaffolding and the consumer/provider exercise boundary are in `tests/contracts/`.

JMeter 5.6.3 is included as an optional Compose tool, so a separate host installation is not required. With the application stopped or running, prepare Activity 8 and execute its safe five-request baseline with:

```bash
rm -rf tests/performance/jmeter/results/baseline.jtl \
       tests/performance/jmeter/results/baseline-report
docker compose --profile tools run --rm jmeter
```

The command starts any required application services, waits for the API health check, and writes the results under `tests/performance/jmeter/results/`. See the [JMeter starter guide](tests/performance/jmeter/README.md) for host-install and comparison-run alternatives.

## API discovery

* API Swagger: http://localhost:5000/swagger
* Simulator Swagger: http://localhost:5100/swagger
* API health: http://localhost:5000/health
* Simulator health: http://localhost:5100/health

## Troubleshooting

* Wait for Compose health checks if the UI initially has no data.
* Check `docker compose ps` and `docker compose logs api` for database startup issues.
* If `sdet-training-api-1` is unhealthy after an update, do not use `docker compose start`; rebuild it with `docker compose up --build --force-recreate` so that the known-good API image and health check are installed.
* Inspect the actual API failure with `docker compose logs api`. If its logs report missing or incompatible database objects, remove the disposable training database with `docker compose down -v`, then run `docker compose up --build --force-recreate` again. Removing the volume deletes locally changed training data.
* Reset state via the endpoint above; use `docker compose down -v` for a completely fresh database.
* Port conflicts can be resolved by changing only the host-side mappings in `docker-compose.yml`.
* A simulator V2 response is intentionally incompatible with the current API consumer; return the scenario to **Normal**.
