# BloodManagementApp

A .NET console application that processes blood test lab reports to identify urgent high-cholesterol tests. The project demonstrates a clean separation of concerns with models, services, and unit tests using MSTest.

## Technologies

- .NET 10
- C# 13
- MSTest 4.0.1 (unit testing)

## Key Features

- **BloodTest model**: Implements the `IBloodTest` interface with `TestName`, `ResultValue`, and `IsFastingRequired` properties.
- **LabReportProcessor service**: Filters and returns test names that:
  - Contain "Cholesterol" (case-insensitive)
  - Have a result value above a configurable threshold
  - Require fasting
  - Have a non-empty test name
- **Unit tests**: Three test methods covering normal results, empty input, and null input (expects `ArgumentNullException`).

## How to Run

```bash
dotnet run --project BloodManagementApp/BloodManagementApp.csproj
```

To run tests:

```bash
dotnet test BloodManagementApp/BloodManagement.Tests/BloodManagement.Tests.csproj
```
