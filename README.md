# GitCore

Pure managed C# implementation for reading from Git repositories.

No dependencies on native code or file system operations.

## History

So far, in .NET-based applications, I've used LibGit2Sharp to clone Git repositories and read their files.
That often works, but the native dependencies of such a solution have caused [many](https://github.com/pine-vm/pine/commit/ba6abfc96a31d5eb87e2345a06d4854778ba80c3) [problems](https://github.com/pine-vm/pine/commit/1c7d3e47f6b847b5302eed07d27c4b3e624f15b8).

For any app that's hosted in .NET anyway, a pure managed implementation seems the natural way to simplify builds and operations.

