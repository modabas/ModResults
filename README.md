# ModResults

[![Nuget](https://img.shields.io/nuget/v/ModResults.svg)](https://www.nuget.org/packages/ModResults/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/modabas/ModResults/blob/main/LICENSE.txt)

ModResults implements the Result pattern, providing a structured way to represent the outcome of operations as either success or failure. Instead of using exceptions or loosely-typed error codes, ModResults encapsulates operation results in strongly-typed objects to improve code readability, maintainability, and error handling. Uses nullability annotations for safer, more predictable code.

## ✨ Features

- **Result Pattern**: Encapsulates success or failure states with associated error messages and additional information.
- **East-to-Use**: Simplifies error handling and result management with a clear API.
- **Serialization**: System.Text.Json serialization support without need for special configuration. Microsoft.Orleans serialization support via `ModResults.Orleans` package.
- **Ready-to-Use Implementations**:
  - `Result` and `Result<TValue>` with a default `Failure` state.
  - `Result<TValue, TFailure>` for custom failure states.
- **📦 Extension Packages for Various Scenarios**: 
  - `ModResults.FluentValidation` bridges FluentValidation with ModResults for unified validation error handling.
  - `ModResults.MinimalApis` provides extensions to convert Result and Result&lt;TValue&gt; instances to ASP.NET Core Minimal APIs' IResult responses with proper HTTP status codes and response formatting.
  - `ModResults.Orleans` provides necessary surrogate, converter and populator implementations required by the Orleans serializer.

---

## 🛠️ How To Use

### Creating a Result or Result&lt;TValue&gt; Instance

- **Success**: Use `Result.Ok()` or `Result<TValue>.Ok(TValue value)`.
- **Failure**: Use static factory methods like `Result.NotFound()` or `Result<TValue>.Invalid()` to create failed results with a specific failure type.

For each failure type (like Error, Forbidden, Unauthorized, etc.), there are several overloads that creates a failed result with the given FailureType:
- No parameters:
Creates a failed result with the given FailureType and no errors.
- String[] errorMessages:
Converts each string to an Error and includes them in the result.
- Error[] errors:
Directly includes the provided Error objects in the result.
- Exception[] exceptions:
Converts each exception to an Error and includes them in the result.

These methods make it easy and consistent to create failed results with detailed error information, categorized by failure type, for both non-generic and generic result types.

``` csharp
public async Task<Result<GetBookByIdResponse>> GetBookById(GetBookByIdRequest req, CancellationToken ct)
{
    var entity = await db.Books.FirstOrDefaultAsync(b => b.Id == req.Id, ct);

    return entity is null ?
      Result<GetBookByIdResponse>.NotFound() :
      Result.Ok(new GetBookByIdResponse(
        Id: entity.Id,
        Title: entity.Title,
        Author: entity.Author,
        Price: entity.Price));
}
```

### Checking the State of a Result

A result can be either in an Ok or Failed state.

- **Ok State**: If the `IsOk` property is true (`IsFailed` is false), a `Result<TValue>` instance will have a non-null `Value` property of type `TValue`.
- **Failed State**: If the `IsOk` property is false (`IsFailed` is true), both `Result` and `Result<TValue>` instances will have a non-null `Failure` property.

>**Note**: When using nullable contexts, the compiler will not generate "may be null" warnings in these cases, as the library leverages conditional attributes to assist null-state analysis.

``` csharp
public async Task<Result> PerformGetBookById(GetBookByIdRequest req, CancellationToken ct)
{
    var result = await GetBookById(req, ct);
    if (result.IsOk)
    {
        Console.WriteLine($"GetBookById is successful. Book title is {result.Value.Title}");
    }
    else
    {
        Console.WriteLine($"GetBookById has failed.");
    }
    return result
}
```

### Explore More Features

For further examples showcasing other functionalities, refer to the following:

- [Implicit Operators and QoL Features](./docs/ImplicitOperators.md)
- [Adding Information to Result Objects](./docs/AddingInformation.md)
- [Create a Failed Result from Exception](./docs/HandlingExceptions.md)
- [Converting a Result to Another Result](./docs/ConvertingResults.md)
- [Mapping Results into Other Objects](./docs/MappingResults.md)
- [Minimal API Integration](./docs/MinimalApiIntegration.md): If you are using Minimal APIs and want to convert a `Result` or `Result<TValue>` into an API response, check out the `WebResultEndpoint` in the [ModEndpoints](https://github.com/modabas/ModEndpoints) project. This project structures ASP.NET Core Minimal APIs as REPR format endpoints and integrates smoothly with the result pattern, providing automatic response mapping.
