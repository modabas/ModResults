## Implicit Operators and Quality of Life (QoL) Features

`Result` and `Result<TValue>` classes provide implicit operators and quality of life (QoL) features to simplify the creation and handling of results in your code. These features allow you to easily convert between different types and create results without needing to explicitly call factory methods.

The `FailedResult` class serves as a helper for returning failed `Result<TValue>` instances without needing to specify `TValue` directly, using implicit conversion operators. It is also designed for easy conversion to both `Result` and `Result<TValue>` types, enabling seamless integration of failure information into your result handling.

### Implicit Operators

- `TValue` to successful `Result<TValue>`,
- `FailureType` enum to failed `Result` or `Result<TValue>`,
- `FailureType` enum to `FailedResult`,
- `Exception` to failed `Result` or `Result<TValue>` with FailureType set to CriticalError,
- `Exception` to `FailedResult` with FailureType set to CriticalError,
- `Result<TValue>` to `Result`.
- `FailedResult` to failed `Result` or `Result<TValue>` copying all Failure information, Errors, Facts, and Warnings.

### QoL Features

- `Result.Ok(TValue value)` static method for creating a successful `Result<TValue>` instead of calling `Result<TValue>.Ok(TValue value)`,
- Static factory methods for creating failed results with specific failure types, such as `Result.NotFound()`, `Result<TValue>.Invalid()`, etc.
- Static `Fail` method to create a failed `Result` or `Result<TValue>` from another `Result` or `Result<TValue>` instance, copying all Failure information, Errors, Facts, and Warnings.
- `Result<TValue>` to `Result` using `ToResult()` method,
- `Result` to `Result<TValue>` using `ToResult()` method with a factory function for `TValue`,
- `FailedResult` to `Result<TValue>` and `Result` using `ToResult<TValue>()` and `ToResult()` methods,
- Extension methods like `ToResultAsync()` or `MapAsync()` for asynchronous conversions,
- Extension methods to check items in Error, Fact, Warning collections and to add new items to Fact and Warning collections.