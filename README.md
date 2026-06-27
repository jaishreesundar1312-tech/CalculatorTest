# CalculatorTest — Renaissance Global Programming Challenge

A small full-stack solution implementing the `ISimpleCalculator` contract.

```
CalculatorTest.sln
├── src/
│   ├── Calculator.Core/      # Class library: ISimpleCalculator + SimpleCalculator
│   └── Calculator.Api/       # ASP.NET Core minimal-API web service
├── tests/
│   └── Calculator.Tests/     # xUnit unit tests
└── calculator-web/           # Angular front-end (modal calculator + live theming)
```

## Requirements coverage

| # | Requirement | Where |
|---|-------------|-------|
| 1 | Empty solution `CalculatorTest` | `CalculatorTest.sln` |
| 2 | Class library with the interface | `src/Calculator.Core/ISimpleCalculator.cs` |
| 3 | C# class implementing the interface | `src/Calculator.Core/SimpleCalculator.cs` |
| 4 | Unit tests | `tests/Calculator.Tests/SimpleCalculatorTests.cs` |
| 5 | Web service exposing the calculator | `src/Calculator.Api/Program.cs` |
| 6 | Angular web app to invoke operations | `calculator-web/` |
| 7 | Operations in a modal with header + footer | `calculator-web/src/app/modal/` |
| 8 | Works across screen sizes / devices | responsive CSS + viewport meta |
| 9 | Restyle the modal from the main page (optional) | theme panel in `app.component` |

## Prerequisites

- **.NET 8 SDK** (`dotnet --version` → 8.x) — required
- **Node.js 18+ and npm** (for the Angular front-end)
- One of the following to work with the .NET solution:
  - **Visual Studio 2022** (17.8 or later) on Windows, **or**
  - the **`dotnet` CLI** (cross-platform — macOS, Linux, Windows)
- Angular CLI is **not** required globally — the front-end uses the
  locally installed CLI via `npm`.

> The .NET solution and the Angular app run independently. The Angular app
> is **not** part of the `.sln`; it is served separately via npm (this is
> standard for Angular and applies on every platform, including Windows).

## 1. Run the .NET solution

### Option A — Visual Studio 2022 (Windows)

1. Double-click **`CalculatorTest.sln`** to open it in Visual Studio.
2. **Build** the solution (`Ctrl+Shift+B`).
3. **Run the tests** via *Test Explorer* (requirement 4).
4. Set **`Calculator.Api`** as the startup project and press **F5** —
   Swagger UI opens automatically at <http://localhost:5000/swagger>
   (requirement 5).

### Option B — `dotnet` CLI (macOS / Linux / Windows)

From the repository root:

```bash
# Restore + build everything
dotnet build CalculatorTest.sln

# Run the unit tests (requirement 4)
dotnet test

# Start the web service (requirement 5) — listens on http://localhost:5000
dotnet run --project src/Calculator.Api
```

Swagger UI is available at <http://localhost:5000/swagger>.

Example calls:

```
GET http://localhost:5000/api/calculator/add?start=5&amount=3        -> 8
GET http://localhost:5000/api/calculator/subtract?start=5&amount=3   -> 2
```

## 2. Run the Angular front-end

In a second terminal:

```bash
cd calculator-web
npm install        # first time only
npm start          # serves http://localhost:4200
```

Open <http://localhost:4200>, click **Open Calculator**, and perform
add/subtract operations in the modal. Use the **Customise the popup**
panel on the main page to restyle the modal live.

> The front-end calls the API at `http://localhost:5000`. If you change the
> API port, update `calculator-web/src/environments.ts`. CORS for
> `http://localhost:4200` is already configured in the API.

## Assumptions

- The interface uses `int`, so arithmetic is done in a `checked` context;
  overflow surfaces as an error (HTTP 400) instead of silently wrapping.
- The web service is a stateless minimal API; the calculator is registered
  via dependency injection behind its interface.
