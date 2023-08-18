# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Release v8.0.0

Features within MooVC that were intended to address shortcomings within the .NET Framework have now been removed in favour of the standardized offering or accepted best practice.

## Enhancements

- Added Hosting.ThreadSafeHostedService to provide similar functionality as that provided by Processing to Microsoft.Extensions.Hosting.IHostedService.
- Added reference to Ardalis.GuardClauses.
- Changed Collections.Concurrent.ProducerConsumerCollectionExtensions.Extract to return IReadOnlyList<T> instead of IEnumerable<T>.
- Changed Collections.Generic.EnumerableExtensions.Aggregate to return IReadOnlyList<T> instead of IEnumerable<T>.
- Changed Collections.Generic.EnumerableExtensions.Process to return IReadOnlyList<T> instead of IEnumerable<T>.
- Changed Collections.Generic.EnumerableExtensions.ProcessAll to return IReadOnlyList<T> instead of IEnumerable<T>.
- Changed Collections.Generic.EnumerableExtensions.ProcessAllAsync to return IReadOnlyList<T> instead of IEnumerable<T>.
- Changed Linq.PagedResult<T> so that now implements IReadOnlyList<T> (**Breaking Change**).
- Changed Linq.Paging so that it can no longer be extended (**Breaking Change**).
- Changed methods accepting a CancellationToken so that it is no longer an optional parameter (**Breaking Change**).
- Changed the default CompressionLevel on each Compression implementation from SmallestSize to Optimal (**Breaking Change**).
- Changed Threading.ICoordinatable<T> so that it no longer accepts a generic type (**Breaking Change**).
- Moved Collections.Generic.ObjectExtensions.AsArray to ObjectExtensions.AsArray (**Breaking Change**).
- Removed Diagnostics (**Breaking Change**).
- Removed Ensure (**Breaking Change**).
- Removed Linq.Paging.Apply (**Breaking Change**).
- Removed Persistence.IEventStore (**Breaking Change**).
- Removed Persistence.SynchronousEventStore<T, TIndex> (**Breaking Change**).
- Removed Processing (**Breaking Change**).
- Removed support for legacy serialization (**Breaking Change**).
- Removed support for async event handling (**Breaking Change**).
- Removed MulticastDelegateExtensions (**Breaking Change**).
- Restored support for .NET Standard 2.0.