# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Upcoming Release v3.0.0

## Overview

MooVC has been upgraded to target .Net 5.0, taking advantage of the many new language features which can be found [here](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five).

## Enhancements

- Added a new Diagnostics namespace, intended to support a more scalable variant of passive information emission than that provided by the Logging namespace.
- Added a new variant of Ensure.ArgumentIsAcceptable that does not require a message.
- Added Async variants of Persistence.IEventStore, Persistence.IStore and Persistence.MappedStore.
- Added Async variant of Threading.Coordinator.Apply.
- Added new Min and Max extensions for DateTimeOffset.
- Added Processing.ThreadSafeHostedService, a class designed to enabled IHostedServices to take advantage of the thread safe features offered by the Processing.ThreadSafeProcessor.
- Annotated extensions to better support static analysis for null state.
- Created new contextual resource files and migrated resources from centralized resource file.
- Changed Processing.IProcessor so that it now inherits from Microsoft.Extensions.Hosting.IHostedService (**Breaking Change**).
- Changed the constituents of Processing namespace to account for new Processing.IProcessor signature.
- Changed Processing.ProcessorStateChangedEventArgs so that it is now serializable.
- Changed Processing.StartOperationInvalidException so that it is now serializable.
- Changed Processing.StopOperationInvalidException so that it is now serializable.
- Changed the type of the first parameter of Processing.ProcessorStateChangedEventHandler to IProcessor (**Breaking Change**).
- Changed Linq.Paging to a Record type (**Breaking Change**).
- Changed TimedProcessor to comform to the new IProcessor interface (**Breaking Change**).
- Modified Serialization extensions to account for null state (**Breaking Change**).
- Deleted Net.ICredentialProvider from the Net namespace (**Breaking Change**).
- Deleted Persistence.EmittedEventArgs<T> from the Persistence namespace (**Breaking Change**).
- Deleted Serialization.Clone extension (**Breaking Change**).
- Deleted the Logging namespace (**Breaking Change**).
- Deleted the Transactions namespace (**Breaking Change**). 

## Bug Fixes

- Min and Max extensions for DateTime to no longer use OADate values due to slight discrepency on return value.
- Paging is now correctly annotated as ISerializable.

## End-User Impact

### Logging (Impact: High)

The members of the Logging namespace where intended to facilitate passive emission of diagnostic information without directly coupling a class with a logging framework.  Two separate flavours where provided, Warning and Failure.  One challenge that presented with this approach was the need for observers to select specific levels to observe by directly targetting a specific implementation type.  This made it very difficult to scale the solution to support a variety of levels (e.g. Debug, Trace, Information).  These concepts have now been reimplemented under the MooVC.Diagnostics namespace, with a single interface encapsulating a wider range of possible levels.

The Aggregate extension has also been replaced with two new extensions.  The first, called Invoke, will trigger a given action on each member and aggregate the diagnostics messages raised during that invocation.  The second, called Throw, will enable the caller to trigger an exception if one or more members of a diagnostics collection matches a given predicate.

### Processing (Impact: High)

The IHostedService from Microsoft.Extensions.Hosting addresses many of the core features offered by IProcessor.  Two features found absent are the ability to determine the state of the processor and the ability guarantee thread safety.  It has therefore been decided to retain IProcessor, with the caveat that it will now implement the Microsoft.Extensions.Hosting.IHostedService interface, thereby allowing for processors implementations to be consumed by a more broad range of consumers.  A new ThreadSafeHostedService has also been added to enable IHostedServices to gain the aforementioned traits of IProcessor, should they be required.  As there are significant differences between the original and new IProcessor implementations, significant impact on existing code consumers is expected.

### Serialization.Clone (Impact: High)

The Clone extension was deemed to be very useful, particular on test projects.  Regretable, the BinaryFormatter used to implement the extension has been marked obsolette and is disabled in ASP.NET apps since Net 5 (see [here](https://docs.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete)).  The suggested alternatives provided directly by the framework have proven to be unworkable, producing failures in a wide range of possible serialization scenarios.  As the MooVC framework is intended to provide functionalities common to all applications, coupling MooVC to a third-party package to restore this feature was deemed to be inappropriate.

### Null State (Impact: Medium)

The signatures of a number of serialization extensions have been changed to facilitate the propagation of null values.  As the previous variants did not explicitly permit null, it has been assumed that a default value should be used and, where not available, an exception thrown.  Default values will apply to String (Empty) and IEnumerable<T> (new T[0]), with a SerializationException throw for Value<T> as it is not possible to determine the default in this circumstance.

### Linq.Paging (Impact: Low)

An instance of Paging will now be deemed to be equal to that of another if the Size and Page values between the two separate instances are the same.  This means that any new instance that shares the same values as the Default instance will now be deemed to be IsDefault.  This was not the case prior to v3.0.0.

### Net.ICredentialProvider (Impact: Low)

The ICredentialProvider interface was not referenced anywhere in the MooVC framework or within any of its known dependants.  It has been marked as deprecated since v2.3.0 and therefore, the impact is expected to be minimal.

### Persistence.EmittedEventArgs<T> (Impact: Low)

The EmittedEventArgs<T> class was not used anywhere in the MooVC framework or within any of its known dependants.  It has been marked as deprecated since v2.3.0 and therefore, the impact is expected to be minimal.

### Processing.ProcessorStateChangedEventHandler (Impact: None)

The event handler requires an argument that was previously only possible to create internally.  It is therefore expected that this change will have zero impact.

### Transactions (Impact: Low)

The Transactions namespace was not used anywhere in the MooVC framework or within any of its known dependants.  The impact of its unplanned removal is expected to be minimal.