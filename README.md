# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Release v8.0.0

## Enhancements

- Changed optional CancellationToken parameters so that they are no longer marked as nullable (**Breaking Change**).
- Changed the default CompressionLevel on each Compression implementation from SmallestSize to Optimal (**Breaking Change**).
- Removed Persistence.IEventStore (**Breaking Change**).
- Removed Persistence.SynchronousEventStore<T, TIndex> (**Breaking Change**).
- Removed Processing.TimedJobQueue<T> (**Breaking Change**).
- Removed Processing.TimedProcessor (**Breaking Change**).
- Restored support for .NET Standard 2.0.