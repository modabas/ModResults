# ModResults

Result Pattern that provides a structured way to represent success or failure with optional details, enhancing readability and maintainability in codebases and designed to be used either in-process or over the network.

It is robust, leveraging nullability annotations, immutability (init properties), and factory methods for clarity.

Contains [Result and Result&lt;TValue&gt;](./src/ModResults/Result.cs) implementations with a default [Failure](./src/ModResults/Failure.cs) implementation which are ready to be used out of the box.

Also contains a [Result&lt;TValue, TFailure&gt;](./src/ModResults/[Core]/Result.cs) implementation, but this requires further development for a custom failure class at least.
