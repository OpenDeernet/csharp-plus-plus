# C#++

Small building blocks that extend C# with patterns found in other languages.

## Cspp.Results

[![NuGet](https://img.shields.io/nuget/v/Cspp.Results?logo=nuget)](https://www.nuget.org/packages/Cspp.Results)

A `Result` type for returning success or failure without throwing exceptions. It is built on C# union types (`[Union]` / `IUnion`).

| Type | Description |
|---|---|
| `Result` | A union of `Success` or `Failure`. |
| `Result<T>` | A union of `Success<T>` (holds a `Value`) or `Failure`. |
| `Failure` | Holds an `Error`. |
| `Error` | A `Code` and a `Message`, neither of which can be null or whitespace. `Error.Unknown` is a predefined default. |

### Usage

```csharp
using Cspp.Results;

Result<int> Parse(string text) =>
    int.TryParse(text, out int value)
        ? Result.FromValue(value)
        : Result.FromError(new Error("Parse.Invalid", $"'{text}' is not a number."));

string message = Parse("42") switch
{
    Success<int> success => $"Parsed {success.Value}",
    Failure failure => $"{failure.Error.Code}: {failure.Error.Message}",
};
```

Union pattern matching works on the case value directly, so no casting is needed. Because the union's cases are known, the switch is exhaustive without a discard (`_`) arm. If you only need to check which case you have, `result.IsSuccess` and `result.IsFailure` are also available.

For the non-generic `Result`, use the predefined `Result.Success` and `Result.Failure` (which carries `Error.Unknown`), or convert a `Success` or `Failure` to `Result` implicitly.

`new Success<T>()` and `new Failure()` are marked obsolete and throw `InvalidOperationException`. Always pass a value or an error.

## Requirements

- .NET 11 SDK. The project targets `net11.0` and needs a C# version that supports union types.

## Building and testing

```sh
dotnet build CSharpPlusPlus.slnx
dotnet test CSharpPlusPlus.slnx
```

Tests use NUnit with the constraint model (`Assert.That`). There is one fixture per class under test, and test names follow `Member_Scenario_ExpectedResult`.

The build treats warnings as errors and runs StyleCop analyzers. Package versions are managed centrally in `Directory.Packages.props`.

## Repository layout

```
src/Cspp.Results/         Result library
test/Cspp.Results.Tests/  NUnit tests
```

## License

Licensed under the [MIT License](LICENSE).