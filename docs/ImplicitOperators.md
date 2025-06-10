## Implicit Operators and Quality of Life (QoL) Features

`Result` and `Result<TValue>` classes provide implicit operators and quality of life (QoL) features to simplify the creation and handling of results in your code. These features allow you to easily convert between different types and create results without needing to explicitly call factory methods.

### Implicit Operators

- `TValue` to successful `Result<TValue>`,
- `FailureType` enum to failed `Result` or `Result<TValue>`,
- `Exception` to failed `Result` or `Result<TValue>` with FailureType set to CriticalError,
- `Result<TValue>` to `Result`.

### QoL Features

- `Result.Ok(TValue value)` static method for creating a successful `Result<TValue>` instead of calling `Result<TValue>.Ok(TValue value)`,
- Static factory methods for creating failed results with specific failure types, such as `Result.NotFound()`, `Result<TValue>.Invalid()`, etc.
- Static `Fail` method to create a failed `Result` or `Result<TValue>` from another `Result` or `Result<TValue>` instance, copying all Failure information, Errors, Facts, and Warnings.
- `Result<TValue>` to `Result` using `ToResult()` method,
- `Result` to `Result<TValue>` using `ToResult()` method with a factory function for `TValue`,
- Extension methods like `ToResultAsync()` or `MapAsync()` for asynchronous conversions,
- Extension methods to check items in Error, Fact, Warning collections and to add new items to Fact and Warning collections.