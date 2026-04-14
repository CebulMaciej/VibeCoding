## Code Style (concrete rules)

1. Naming:
   - Types and public members: PascalCase (e.g. `HealthService`, `GetStatus`).
   - Parameters and local variables: camelCase (e.g. `httpClient`, `userId`).
   - Interfaces: prefix with `I` + PascalCase (e.g. `IHealthService`).

2. Async / await:
   - Asynchronous methods MUST end with `Async` (e.g. `GetHealthAsync`).

3. Use of `var`:
   - Use `var` only when the type is obvious from the right-hand side (e.g. `var stream = new MemoryStream();`). Otherwise use explicit types.

4. Formatting and indentation:
   - 4 spaces per indent level. Maximum line length: 120 characters.
   - No trailing whitespace. Run `dotnet format` before committing.

5. Files and single-type rule:
   - One public type (class/enum/struct) per file; filename should match the type name.

6. Nullability and type-safety:
   - Enable nullable reference types and use `?` where a value can be null.

7. Comments and documentation:
   - Document public API with XML comments (`/// <summary>...`). Keep small methods self-explanatory—avoid excessive comments.

## Project Structure

High-level layout (root: `/src`):

- `VibeCoding.Api/` — ASP.NET Core Web API project. Contains controllers, DTOs, app configuration and `Program.cs`.
- `VibeCoding.Application/` — application logic, service interfaces, use-cases and entry points into the domain.
- `VibeCoding.Domain/` — domain entities, value objects, domain exceptions and core business rules.
- `VibeCoding.Infrastructure/` — concrete implementations (repositories, external adapters), DI wiring for adapters.

Other notable files:

- `global.json` — pins .NET SDK version for the repo.
- `README.md` — high-level project information.
- `.github/` — CI workflows, contributing docs and policies (this file lives here).

Note: If you add a new project, put it under `src/` and register it in the solution `.sln`.

## Workflow — commands (macOS / zsh)

Run these from the repository root.

1) Restore dependencies:

```bash
dotnet restore
```

2) Build (compile + type checks):

```bash
dotnet build --no-restore
```

3) Run API locally (development):

```bash
dotnet run --project src/VibeCoding.Api
```

4) Tests (if present):

```bash
dotnet test --no-build
```

5) Formatting / linting:

Install (if not already installed):

```bash
dotnet tool install -g dotnet-format
```

Run formatter:

```bash
dotnet format
```

6) CI / static checks:

In CI run: `dotnet restore`, `dotnet build --no-restore`, `dotnet test --no-build`, and optionally `dotnet format --verify-no-changes` to enforce formatting.

## Constraints (rules and restrictions)

1. Never commit secrets or credentials into the repository.

2. Keep pull requests small and focused—prefer PRs that close a single feature or bugfix.

3. SDK compatibility: use the .NET SDK version specified in `global.json`. Do not bump the SDK without discussion.

4. Tests: new features must include appropriate unit/integration tests. No regressions allowed.

5. Public API and contracts: breaking changes require an architecture review and migration notes.

6. Do not modify generated files (e.g. files under `obj/` or `bin/`) in commits.

## Code Review & PR checklist

- Does `dotnet build` succeed locally with no errors?
- Does `dotnet format` introduce no additional changes?
- Are tests added/updated for new behavior?
- Does the PR description explain the change and how to run it?

## Collaborating with Copilot / AI (short guidance)

- Provide clear context in prompts: target file(s), project path, and the exact method or class to change.
- If the request changes public API, include compatibility notes and required tests.
- Prefer small, iterative changes (1–2 files). After each iteration run build and tests.

## DO / DON'T

DO:
- Use dependency injection for all services
- Keep controllers thin — move logic to Application layer
- Use async/await for all I/O operations

DON'T:
- Do not put business logic in controllers
- Do not access Infrastructure directly from Api
- Do not use static state or singletons for services.