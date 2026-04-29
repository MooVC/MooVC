# Root Instructions for Codex

This repository hosts **MooVC**, a .NET library that contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

> **Note**
> This file provides quick instructions for Codex. Human contributors should refer to the
> [README](README.md) and [CONTRIBUTING guide](.github/CONTRIBUTING.md) for a fuller picture.

## Build and Test

- Use the .NET SDK **10.0**. The latest SDK can be found at [dotnet.microsoft.com](https://dotnet.microsoft.com/).
- Restore packages with `dotnet restore`.
- Run `dotnet test` to execute the test suite. This is the primary check before committing.
- Tests are configured via `.runsettings` and use xUnit.
- If `dotnet` is not available in the current container/session, install SDKs before running checks.
  - Linux/macOS bootstrap:
    - `curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh`
    - `bash /tmp/dotnet-install.sh --channel 8.0 --install-dir "$HOME/.dotnet"`
    - `bash /tmp/dotnet-install.sh --channel 9.0 --install-dir "$HOME/.dotnet"`
    - `bash /tmp/dotnet-install.sh --channel 10.0 --install-dir "$HOME/.dotnet"`
    - `export PATH="$HOME/.dotnet:$PATH"`
    - `dotnet --list-sdks`
  - Match CI SDK coverage (`8.0.x`, `9.0.x`, `10.0.x`) when validating the full solution.

## Coding Style

The project enforces strong C# coding conventions through `.editorconfig`, [StyleCop Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers), and [SonarAnalyzer for C#](https://github.com/SonarSource/sonar-dotnet). Key points from the [Contributing guide](.github/CONTRIBUTING.md):

- Prefer **file-scoped namespaces**.
- Follow Microsoft naming guidelines (PascalCase for types and members, camelCase for locals/parameters, prefix interfaces with `I`).
- Seal classes when extension is not intended.
- Use discards (`_`) for unused values.
- Organize extension methods so each file is named `{TypeName}Extensions.{MethodName}.cs`.
- Use resource files for all user-facing strings with names `{TypeName}.Resources.{locale}.resx` and keys formatted as `{Context}{Subject}{Purpose}`.
- Avoid `#region` pragmas.
- Avoid placing a newline character at the end of files.
- File may not end with a newline character.
- Avoid abrieviations in names, except for well-known acronyms (e.g., `Http`, `Xml`).
- Avoid single-letter names, even for loop variables.
- Avoid qualified types, use `using` directives instead or an alias if necessary.
- Use `var` for local variables when the type is clear from the right-hand side.
- Use `nameof` for member names in exceptions and logging.
- Use `string.Empty` instead of `""` for empty strings.
- When possible, place declarations in alphabetical order (e.g. fields, parameters, properties, methods).

### Unit Testing Conventions

- Follow **Arrange-Act-Assert** structure.
- Place tests for a class under a matching namespace `{Class Namespace}.{Class Name}Tests`.
- Name test classes `When{MethodName}IsCalled` and test methods `Given{Condition}When{State}Then{Expectation}`. If no {State} is needed, use `Given{Condition}Then{Expectation}`. Do not use the MethodName in the test name, as all tests in the class relate to the same method and the class name identified the method name.
- Use [`Shouldy`](https://docs.shouldly.org/) and `NSubstitute` for assertions and mocks.
- Use constants for test data, especially for strings and numbers, to avoid magic values.

## Project Structure

- Production code resides in `src/`.
- Tests live in `src/*.Tests` and mirror the main project layout.
- Documentation for analyzers is under `docs/rules`.

## Pull Requests

The [PR template](.github/pull_request_template.md) requires that you:

- Follow the coding style.
- Add or update tests when necessary.
- Ensure tests pass locally.
- Update `CHANGELOG.md` when consumer-facing changes occur.

## Mandatory Workflow for Codex

To reduce regressions and incorrect API usage, Codex must follow this workflow for every code change:

1. **Load repository rules first**
   - Read `AGENTS.md`, `.editorconfig`, and `Directory.Build.props` before editing files.
   - Determine whether the target project is a library, Roslyn project, or test project so the correct imported props/ruleset applies.
2. **Verify symbols before writing code**
   - Never assume a member exists based on similarly named types.
   - Before using or changing APIs, confirm the exact symbol names from source files.
3. **Make minimal, scoped edits**
   - Change only files required by the task.
   - Reuse existing patterns from neighboring files/tests.
4. **Run required validation commands**
   - Run `dotnet restore`.
   - Run `dotnet test` (or at minimum run tests for each affected project/target framework).
   - Do not create a commit if restore/build/tests fail.
5. **Self-check before commit**
   - Confirm no `.editorconfig` violations.
   - Confirm no analyzer/ruleset violations from `analyzers/` as configured by imported props.
   - Confirm test naming and structure conventions from this file are followed.

## Rule Enforcement Notes

- `.editorconfig` is authoritative for formatting, naming, `var` usage, namespace style, and newline behavior.
- Analyzer severities are enforced through project configuration and rulesets in `analyzers/`.
- Test projects use `build/Tests.props`, which assigns `analyzers/tests.ruleset`.
- Non-test code paths use their corresponding imported props (`build/Libraries.props` or `build/Roslyn.props`) and configured analyzers.

## Common Failure Prevention

- If two option types have different static instances, always verify each concrete type instead of copying usage from another type.
- When adding or updating tests, compile and run the affected test project immediately after the change.
- If a requested symbol does not exist, stop and either:
  - use an existing valid symbol, or
  - add the symbol intentionally in production code with tests, if that is part of the requested change.