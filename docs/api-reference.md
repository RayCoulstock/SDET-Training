# API reference

Interactive OpenAPI is at `http://localhost:5000/swagger`. All domain routes begin `/api`.

| Method | Route | Notes |
|---|---|---|
| GET/POST | `/api/participants` | `search`, `status`; create participant |
| GET/PUT | `/api/participants/{id}` | participant detail/update |
| GET/POST | `/api/devices` | `connection`, `assigned`; create device |
| GET | `/api/devices/{id}` | device detail |
| POST | `/api/devices/{id}/assign`, `/unassign` | assignment actions |
| GET/POST | `/api/sessions` | `search`, `status`; start recording |
| GET | `/api/sessions/{id}` | expanded session detail |
| POST | `/api/sessions/{id}/stop` | stop a recording |
| GET | `/api/sessions/{id}/telemetry` | readings |
| POST | `/api/telemetry` | telemetry load-test target |
| POST | `/api/training/reset` | deterministic restoration |
| GET/POST | `/api/training/config` | simulator configuration |
| POST | `/api/training/scenarios/{name}` | apply named preset |

The simulator exposes `GET /api/devices/{serialNumber}/status`, `GET /api/devices/{serialNumber}/telemetry`, and training configuration routes on port 5100. Both applications expose `/health`.
