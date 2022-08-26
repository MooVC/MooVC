# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Release v7.0.0

## Enhancements

- Added a Collections.Generic.ObjectExtensions.AsArray extension that will return an array containing the value on which the request was made.
- Added a Collections.Generic.ObjectExtensions.AsEnumerable extension that will return an enumerable containing the value on which the request was made.
- Changed Threading.Coordinator so that it is now extensible i.e. It is no longer static (**Breaking Change**).
- Changed the return type for Persistence.IStore<T, TKey>.GetAsync(CancellationToken, Paging) from IEnumerable<T> to PagedResult<T> (**Breaking Change**).
- Changed the return type for Persistence.MappedStore<T, TOutterKey, TInnerKey>.GetAsync(CancellationToken, Paging) from IEnumerable<T> to PagedResult<T> (**Breaking Change**).
- Changed the return type for Persistence.SynchronousStore<T, TKey>.GetAsync(CancellationToken, Paging) from IEnumerable<T> to PagedResult<T> (**Breaking Change**).
- Changed the return type for Persistence.SynchronousStore<T, TKey>.PerformGet(Paging) from IEnumerable<T> to PagedResult<T> (**Breaking Change**).