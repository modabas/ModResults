# ModResults

[![Nuget downloads](https://img.shields.io/nuget/v/ModResults.svg)](https://www.nuget.org/packages/ModResults/)
[![Nuget](https://img.shields.io/nuget/dt/ModResults)](https://www.nuget.org/packages/ModResults/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/modabas/ModResults/blob/main/LICENSE.txt)

ModResults provides a structured way to represent success or failure with optional details, enhancing readability and maintainability in codebases. It is designed for both in-process and networked scenarios with serialization/deserialization support. The library leverages nullability annotations, immutability, and factory methods for clarity.

## ✨ Features

- **Result Pattern**: Encapsulates success or failure states with associated error messages and additional information.
- **Ready-to-Use Implementations**:
  - `Result` and `Result<TValue>` with a default `Failure` state.
  - `Result<TValue, TFailure>` for custom failure states.
- **📦 Extension Packages for Various Scenarios**: 
  - `ModResults.FluentValidation` bridges FluentValidation with ModResults for unified validation error handling.
  - `ModResults.MinimalApis` provides extensions to convert Result and Result&lt;TValue&gt; instances to ASP.NET Core Minimal APIs' IResult responses with proper HTTP status codes and response formatting.
  - `ModResults.Orleans` provides surrogate and converter implementations required by the Orleans serializer.
- **Serialization**: JSON serialization/deserialization without special configuration.

---

## 🛠️ How To Use

### Creating a Result or Result<TValue> Instance
- **Success**: Use `Result.Ok()` or `Result<TValue>.Ok(TValue value)`.
- **Failure**: Use static methods like `Result.NotFound()` or `Result<TValue>.NotFound()`.

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

A result can either be in an Ok or Failed state.  

- **Ok State**: The `Result<TValue>` instance contains a non-null `Value` of type `TValue`.  
- **Failed State**: Both `Result` and `Result<TValue>` instances contain a non-null `Failure` of type `Failure`.

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

### Advanced Topics  

For more advanced examples, refer to the following:  

- [Adding Information to Results](./docs/AddingInformation.md)
- [Create a Failed Result from Exceptions](./docs/HandlingExceptions.md)
- [Converting a Result to Another Result](./docs/ConvertingResults.md)
- [Mapping Results into Other Objects](./docs/MappingResults.md)
- [Minimal API Integration](./docs/MinimalApiIntegration.md): If you're utilizing Minimal APIs and need to map a `Result` or `Result<TValue>` to an API response, consider exploring the `WebServiceEndpoint` implementation in the [ModEndpoints](https://github.com/modabas/ModEndpoints) project. This project organizes ASP.NET Core Minimal APIs into REPR format endpoints and seamlessly integrates with the result pattern, including automatic response mapping.
- **Microsoft Orleans Integration**: Include ModResults.Orleans package as project dependency to use Result and Result&lt;TValue&gt; objects in Orleans grains.

---
