# Changelog
All notable changes to MooVC will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# [10.1.0] - 2026-11-14

## Added

- C# interface builders support covariant and contravariant type parameters with generic constraints.
- C# syntax builders for binary, unary, and conversion operators accept explicit operand and result types and custom parameter names.
- C# method, property, and indexer builders support explicit interface implementations. Indexers support multiple parameters, and property and indexer builders support setter-only declarations and accessor-specific accessibility.

## Fixed

- Updated Valuify to 1.9.1 so generated indexer hashes use each parameter's value hash.
- C# struct declarations render their implemented interfaces.

# [10.0.3] - 2026-11-13

## Fixed

- `MooVC.Syntax.CSharp` now preserves explicit accessibility on auto-implemented `set` and `init` accessors.

# [10.0.2] - 2026-11-12

## Fixed

- `MooVC.Syntax.Snippet.From` now recognizes CRLF, LF, and CR line endings on every platform and preserves blank lines.

# [10.0.1] - 2026-11-11

## Fixed

- Restored compatibility with the .NET 10 compiler host for analyzers and source generators that depend on MooVC. The `netstandard2.0` and `net10.0` builds use version `10.0.15` of `Microsoft.Bcl.AsyncInterfaces`, the Microsoft.Extensions packages updated in 10.0.0, and `System.Collections.Immutable`. The `net11.0` build uses `11.0.0` for these dependencies.

# [10.0.0] - 2026-11-11

## Added

- Support for .NET 11.

## Updated

- Updated [Apex.Serialization](https://github.com/dbolin/Apex.Serialization) to `8.0.0` for .NET 10.0.
- Updated [Apex.Serialization](https://github.com/dbolin/Apex.Serialization) to `9.0.0` for .NET 11.0.
- Updated [Microsoft.Bcl.AsyncInterfaces](https://github.com/dotnet/runtime) from `10.0.14` to-  `11.0.0`.
- Updated [Microsoft.Extensions.Configuration](https://github.com/dotnet/runtime) from `10.0.14` to-  `11.0.0`.
- Updated [Microsoft.Extensions.Configuration.Binder](https://github.com/dotnet/runtime) from-  `10.0.14` to `11.0.0`.
- Updated [Microsoft.Extensions.DependencyInjection](https://github.com/dotnet/runtime) from `10.0- .14` to `11.0.0`.
- Updated [Microsoft.Extensions.DependencyInjection.Abstractions](https://github.com/dotnet/runtime)-  from `10.0.14` to `11.0.0`.
- Updated [Microsoft.Extensions.Hosting.Abstractions](https://github.com/dotnet/runtime) from-  `10.0.14` to `11.0.0`.
- Updated [Microsoft.Extensions.Logging.Abstractions](https://github.com/dotnet/runtime) from-  `10.0.14` to `11.0.0`.
- Updated [Microsoft.Extensions.Options.ConfigurationExtensions](https://github.com/dotnet/runtime)-  from `10.0.14` to `11.0.0`.
- Updated [System.Collections.Immutable](https://github.com/dotnet/runtime) from `10.0.14` to-  `11.0.0`.

## Removed

- Support for .NET 8 and .NET 9.

# [9.6.0] - 2026-11-04

## Added

- Added standardized Instance and Collection factory support to facilitate the instantiation of infrastructural components without requiring direct knowledge of their concrete types.

## Fixed

- Updated [Graphify](https://github.com/MooVC/graphify) from `1.1.2` to `1.1.3`.
- Updated [Microsoft.Bcl.AsyncInterfaces](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Microsoft.Extensions.Configuration](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Microsoft.Extensions.DependencyInjection](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Microsoft.Extensions.DependencyInjection.Abstractions](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Microsoft.Extensions.Hosting.Abstractions](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Microsoft.Extensions.Logging.Abstractions](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Microsoft.Extensions.Options.ConfigurationExtensions](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.
- Updated [Monify](https://github.com/MooVC/monify) from `1.6.2` to `1.6.3`.
- Updated [System.Collections.Immutable](https://github.com/dotnet/dotnet) from `10.0.13` to `10.0.14`.

# [9.5.2] - 2026-10-14

## Fixed

- Updated [Graphify](https://github.com/MooVC/graphify) from `1.1.1` to `1.1.2`.
- Updated [System.Collections.Immutable](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Bcl.AsyncInterfaces](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Extensions.Configuration](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Extensions.DependencyInjection](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Extensions.DependencyInjection.Abstractions](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Extensions.Hosting.Abstractions](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Extensions.Logging.Abstractions](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.
- Updated [Microsoft.Extensions.Options.ConfigurationExtensions](https://github.com/dotnet/dotnet) from `10.0.12` to `10.0.13`.

# [9.5.1] - 2026-10-14

## Fixed

- Updated [MessagePack](https://github.com/MessagePack-CSharp/MessagePack-CSharp) from `3.1.11` to `3.1.12`.

# [9.5.0] - 2026-10-05

## Changed

- Updated `Graphify` from `1.0.3` to `1.1.0`.

## Fixed

- Updated `MessagePack` from `3.1.10` to `3.1.11`.

# [9.4.1] - 2026-09-27

## Fixed

- Updated `MessagePack` from `3.1.9` to `3.1.10`.

# [9.4.0] - 2026-09-22

## Added

- C# 14 extension blocks with instance and static methods, generic constraints, receiver formatting, and namespace imports.
- Direct implicit conversions from top-level C# options to nested member, parameter, naming, attribute, and qualification settings, preserving existing inheritance and overrides.

# [9.3.4] - 2026-09-22

## Fixed

- C# snippet chaining preserves commas within generic type arguments when splitting parameter and argument lists across lines.

# [9.3.3] - 2026-09-18

## Fixed

- Updated `MessagePack` from `3.1.8` to `3.1.9`.

# [9.3.2] - 2026-09-09

## Fixed

- Updated `Graphify` from `1.0.2` to `1.0.3`.
- Updated `Microsoft.Bcl.AsyncInterfaces` from `10.0.11` to `10.0.12`.
- Updated `Microsoft.Extensions.Configuration` from `10.0.11` to `10.0.12`.
- Updated `Microsoft.Extensions.DependencyInjection` from `10.0.11` to `10.0.12`.
- Updated `Microsoft.Extensions.DependencyInjection.Abstractions` from `10.0.11` to `10.0.12`.
- Updated `Microsoft.Extensions.Hosting.Abstractions` from `10.0.11` to `10.0.12`.
- Updated `Microsoft.Extensions.Logging.Abstractions` from `10.0.11` to `10.0.12`.
- Updated `Microsoft.Extensions.Options.ConfigurationExtensions` from `10.0.11` to `10.0.12`.
- Updated `System.Collections.Immutable` from `10.0.11` to `10.0.12`.

# [9.3.1] - 2026-09-04

## Fixed

- Updated `Graphify` from pre-release to stable Version `1.0.1`.

# [9.3.0] - 2026-09-04

## Added

- A CSharp Syntax generator based on the [Fluent Builder](https://github.com/MooVC/Fluentify) pattern.
- A `ForkOn` extension method that allows for branching logic based on a predicate evaluation within a LINQ call chain.

## Changed

- Improved NuGet package metadata for `MooVC.Modelling` to enhance visibility on nuget.org.
- Normalized `ZipWriter` archive entry paths to forward slashes for cross-platform consistency.

# [9.2.0] - 2025-11-14

## Added

- Targeting for .NET 10.0 across libraries and supporting test projects.

## Fixed

- `ObjectExtensions.ToTypedArray` returns arrays unchanged, avoiding unintended nested arrays.

# [9.1.0] - 2025-06-29

## Changed

- `Apex.Serialization` to Version `6.0.0` for .NET 9 only.
- `MessagePack` to Version `3.1.4`.
- `Microsoft.Extensions.Hosting.Abstractions` to Version `9.0.6`.
- `Microsoft.Extensions.Logging.Abstractions` to Version `9.0.6`.
- Introduced a fluent assertion library for tests.

# [9.0.0] - 2025-03-19

Features within MooVC that were intended to address shortcomings within the .NET Framework have now been removed in favour of the standardized offering or accepted best practice.

## Added

- `Ardalis.GuardClauses`, replacing the Ensure guard centric class.
- `Hosting.ThreadSafeHostedService` to provide similar functionality as that originally provided by the Processing namespace to types deriving from Microsoft.Extensions.Hosting.IHostedService.
- `Linq.IEnumerableExtensions.IsNullOrEmpty` extension for checking if an enumerable is null or has no elements.
- `Linq.IEnumeratorExtensions.ToArray` extension to enumerate an enumerator, returning the values as an array.
- Support for .NET Standard 2.0.
- `System.Text.Json` serializaton through `Serialization.Json.Serializer`.

## Changed

- All `Collections.Generic.EnumerableExtensions` to `Linq.IEnumerableExtensions` (**Breaking Change**).
- `ArrayExtensions.Append` to accept a params array for the elements to be apended to the source array.
- `ArrayExtensions.Prepend` to accept a params array for the elements to be apended to the source array.
- `ArrayExtensions.Snapshot` to `ArrayExtensions.ToCopyOrEmpty` (**Breaking Change**).
- `CancellationToken` to a required parameter on all async capable methods (**Breaking Change**).
- `Collections.Concurrent.ProducerConsumerCollectionExtensions.Extract` to return `IReadOnlyList<T>` instead of `IEnumerable<T>`.
- `Collections.Generic.DictionaryExtensions.Snapshot` extension to `Collections.Generic.IDictionaryExtensions.ToNewOrCopy` (**Breaking Change**).
- `Collections.Generic.EnumerableExtensions.Aggregate` extension to return `IReadOnlyList<T>` instead of `IEnumerable<T>`.
- `Collections.Generic.EnumerableExtensions.Snapshot` extension to `Linq.IEnumerableExtensions.ToArrayOrEmpty` (**Breaking Change**).
- `Collections.Generic.ObjectExtensions.AsArray` extension to `ObjectExtensions.ToTypedArray` (**Breaking Change**).
- `Collections.Generic.ObjectExtensions.AsEnumerable` extension to `Linq.ObjectExtensions.AsEnumerable` (**Breaking Change**).
- `Linq.EnumerableExtensions.IsEmpty` extension so that it no longer accepts a null (**Breaking Change**).
- `Linq.EnumerableExtensions.SafeAny` extension to `Linq.EnumerableExtensions.HasAny` (**Breaking Change**).
- `Linq.Paging` to `Paging.Directive` (**Breaking Change**).
- `Linq.PagedResult<T>` to `Paging.Page<T>` (**Breaking Change**).
- `Serialization.DefaultCloner` to `Cloner` (**Breaking Change**).
- The default `CompressionLevel` on each `Compression` implementation from `SmallestSize` to `Optimal` (**Breaking Change**).
- `Threading.ICoordinatable<T>` so that it no longer accepts a generic type argument (**Breaking Change**).
 
## Removed

- `ArrayExtensions.Extend` extension in favor of `ArrayExtensions.Append` (**Breaking Change**).
- `Async` keyword from all methods (**Breaking Change**).
- `Async` event handling (**Breaking Change**).
- `Collections.Generic.EnumerableExtensions.Process` extension (**Breaking Change**).
- `Collections.Generic.EnumerableExtensions.ProcessAll` extension (**Breaking Change**). 
- `Diagnostics` namespace (**Breaking Change**).
- Ensure class (**Breaking Change**).
- Legacy serialization (Binary Formatter, `SerializableAttribute` and `ISerializable`) (**Breaking Change**).
- `Linq.Paging.Apply` method (**Breaking Change**).
- `MulticastDelegateExtensions` class (**Breaking Change**).
- `Persistence` namespace (**Breaking Change**).
- `Processing` namespace (**Breaking Change**).
