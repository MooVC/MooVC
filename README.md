# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Upcoming Release v4.0.0

## Overview

Added additional support for asynchonrous event handling and cancellation.

## Enhancements

- Added AsyncEventHandler to represent an event handler that can be awaited by the sender.
- Added AsyncEventArgs to represent a event arguments that can be used to cancel operations by the sender.
- Added a MulticastDelegateExtensions.InvokeAsync method that will await the invocation of a multicast delegate that returns a Task.
- Added a MulticastDelegateExtensions.PassiveInvokeAsync method that will await the invocation of a multicast delegate that returns a Task and absorb any error encountered.
- Added a MulticastDelegateExtensions.PassiveInvoke method that will invoke a multicast delegate absorb any errors encountered.
- Changed Collections.Generic.Snapshot to accept an optional predicate to filter the final result.
- Changed method signatures for Persistence.IEventStore to include an optional cancellation token (**Breaking Change**).
- Changed method signatures for Persistence.IStore to include an optional cancellation token (**Breaking Change**).
- Changed the invocation of the ProcessStateChanged event handler of Processing.Processor to utilize the passive implementation.
- Changed the invocation of the DiagnosticsEmitted event handler of Processing.TimedJobQueue to utilize the passive implementation.
- Changed Diagnostics.DiagnosticsEmittedEventHandler to an async variant named Diagnostics.DiagnosticsEmittedAsyncEventHandler (**Breaking Change**).
- Changed Diagnostics.EmitDiagnosticsExtensions.Invoke to an async variant named Diagnostics.EmitDiagnosticsExtensions.InvokeAsync (**Breaking Change**).
- Changed Processing.ProcessorStateChangedEventHandler to an async variant named Processing.ProcessorStateChangedAsyncEventHandler (**Breaking Change**).
- Changed Threading.Initializer so that the delegate now accepts a cancellation token (**Breaking Change**).
- Renamed Persistence.IEventStore.ReadAsync for individual reads to GetAsync due to unintended ambiguity (**Breaking Change**).

## Bug Fixes

- Corrected the scope for the State setter on Processing.Processor (**Breaking Change**).