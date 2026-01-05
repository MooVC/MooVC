# Changelog
All notable changes to MooVC will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# [9.3.0] - TBC

## Added

- A CSharp Syntax generator based on the [Fluent Builder](https://github.com/MooVC/Fluentify) pattern.

# [9.2.0] - 2025-11-14

## Added

- Targeting for .NET 10.0 across libraries and supporting test projects.

## Fixed

- ObjectExtensions.ToTypedArray returns arrays unchanged, avoiding unintended nested arrays.

# [9.1.0] - 2025-06-29

## Changed

- Apex.Serialization to Version 6.0.0 for .NET 9 only.
- MessagePack to Version 3.1.4.
- Microsoft.Extensions.Hosting.Abstractions to Version 9.0.6.
- Microsoft.Extensions.Logging.Abstractions to Version 9.0.6.
- Introduced Shouldly for assertions.

# [9.0.0] - 2025-03-19

Features within MooVC that were intended to address shortcomings within the .NET Framework have now been removed in favour of the standardized offering or accepted best practice.

## Added

- Ardalis.GuardClauses, replacing the Ensure guard centric class.
- Hosting.ThreadSafeHostedService to provide similar functionality as that originally provided by the Processing namespace to types deriving from Microsoft.Extensions.Hosting.IHostedService.
- Linq.IEnumerableExtensions.IsNullOrEmpty extension for checking if an enumerable is null or has no elements.
- Linq.IEnumeratorExtensions.ToArray extension to enumerate an enumerator, returning the values as an array.
- Support for .NET Standard 2.0.
- System.Text.Json serializaton through Serialization.Json.Serializer.

## Changed

- All Collections.Generic.EnumerableExtensions to Linq.IEnumerableExtensions (**Breaking Change**).
- ArrayExtensions.Append to accept a params array for the elements to be apended to the source array.
- ArrayExtensions.Prepend to accept a params array for the elements to be apended to the source array.
- ArrayExtensions.Snapshot to ArrayExtensions.ToCopyOrEmpty (**Breaking Change**).
- CancellationToken to a required parameter on all async capable methods (**Breaking Change**).
- Collections.Concurrent.ProducerConsumerCollectionExtensions.Extract to return IReadOnlyList<T> instead of IEnumerable<T>.
- Collections.Generic.DictionaryExtensions.Snapshot extension to Collections.Generic.IDictionaryExtensions.ToNewOrCopy (**Breaking Change**).
- Collections.Generic.EnumerableExtensions.Aggregate extension to return IReadOnlyList<T> instead of IEnumerable<T>.
- Collections.Generic.EnumerableExtensions.Snapshot extension to Linq.IEnumerableExtensions.ToArrayOrEmpty (**Breaking Change**).
- Collections.Generic.ObjectExtensions.AsArray extension to ObjectExtensions.ToTypedArray (**Breaking Change**).
- Collections.Generic.ObjectExtensions.AsEnumerable extension to Linq.ObjectExtensions.AsEnumerable (**Breaking Change**).
- Linq.EnumerableExtensions.IsEmpty extension so that it no longer accepts a null (**Breaking Change**).
- Linq.EnumerableExtensions.SafeAny extension to Linq.EnumerableExtensions.HasAny (**Breaking Change**).
- Linq.Paging to Paging.Directive (**Breaking Change**).
- Linq.PagedResult<T> to Paging.Page<T> (**Breaking Change**).
- Serialization.DefaultCloner to Cloner (**Breaking Change**).
- The default CompressionLevel on each Compression implementation from SmallestSize to Optimal (**Breaking Change**).
- Threading.ICoordinatable<T> so that it no longer accepts a generic type argument (**Breaking Change**).
 
## Removed

- ArrayExtensions.Extend extension in favor of ArrayExtensions.Append (**Breaking Change**).
- Async keyword from all methods (**Breaking Change**).
- Async event handling (**Breaking Change**).
- Collections.Generic.EnumerableExtensions.Process extension (**Breaking Change**).
- Collections.Generic.EnumerableExtensions.ProcessAll extension (**Breaking Change**). 
- Diagnostics namespace (**Breaking Change**).
- Ensure class (**Breaking Change**).
- Legacy serialization (Binary Formatter, SerializableAttribute and ISerializable) (**Breaking Change**).
- Linq.Paging.Apply method (**Breaking Change**).
- MulticastDelegateExtensions class (**Breaking Change**).
- Persistence namespace (**Breaking Change**).
- Processing namespace (**Breaking Change**).
