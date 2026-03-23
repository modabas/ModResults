## Implicit Operators and Quality of Life (QoL) Features

`Result` and `Result<TValue>` classes provide implicit operators and quality of life (QoL) features to simplify the creation and handling of results in your code. These features allow you to easily convert between different types and create results without needing to explicitly call factory methods.

The `FailureResult` class serves as a helper for returning failed `Result<TValue>` instances without needing to specify `TValue` directly, using implicit conversion operators. It is also designed for easy conversion to both `Result` and `Result<TValue>` types, enabling seamless integration of failure information into your result handling.
``` csharp
    public Result<TValue> AwesomeMethod<TValue>()
    {
      // Some logic that determines the result of the operation
      //...
      // If the operation fails, return a FailureResult which will be implicitly
      // converted to Result<TValue>
      return FailureResult.Conflict();
    }
```

### Implicit Operators

- `TValue` to successful `Result<TValue>`,
- `FailureType` enum to failed `Result` or `Result<TValue>`,
- `FailureType` enum to `FailureResult`,
- `Exception` to failed `Result` or `Result<TValue>` with FailureType set to CriticalError,
- `Exception` to `FailureResult` with FailureType set to CriticalError,
- `Result<TValue>` as `Result` that wraps same state, Failure and Statements in target result type.
- `FailureResult` as failed `Result` or `Result<TValue>` that wraps same state, Failure and Statements in target result type.

### QoL Features

- `Result.Ok(TValue value)` static method for creating a successful `Result<TValue>` instead of calling `Result<TValue>.Ok(TValue value)`,
- Static factory methods for creating failed results with specific failure types, such as `Result.NotFound()`, `Result<TValue>.Invalid()`, etc.
- Static `Fail` method to create a failed `Result` or `Result<TValue>` from another `Result` or `Result<TValue>` instance, copying all Failure information, Errors, Facts, and Warnings.
- `Result<TValue>` to `Result` using `ToResult()` method (in same state, copies contents of Failure and Statement objects of source),
- `Result<TValue>` as `Result` using `AsResult()` method (in same state, uses same Failure and Statement objects of source),
- `FailureResult` to `Result<TValue>` and `Result` using `ToResult<TValue>()` and `ToResult()` methods (in same state, copies contents of Failure and Statement objects of source),
- `FailureResult` as `Result<TValue>` and `Result` using `AsResult<TValue>()` and `AsResult()` methods (in same state, uses same Failure and Statement objects of source),
- `Result` to `Result<TValue>` using `ToResult()` method with a factory function for `TValue`,
- Extension methods like `ToResultAsync()` or `MapAsync()` for asynchronous conversions,
- Extension methods to check items in Error, Fact, Warning collections and to add new items to Fact and Warning collections.