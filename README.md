# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Release v5.0.0

## Overview

This release focuses on standardizing the concept of serialization.

## Enhancements

- Added a Compression.ICompressor to encapsulate the concept of a data compressor.
- Added a Compression.Compressor to support development of streams based compression.
- Added a Compression.SynchronousCompressor to support development of synchsonous compression components.
- Added a Serialization.ISerializer to encapsulate the concept of an object serializer.
- Added a Serialization.SynchronousCloner to support migration to the async variant.
- Added a Serialization.SynchronousSerializer to support development of synchsonous serialization components.
- Changed Serialization.ICloner to no longer require that the type implement System.ISerializable.
- Changed Serialization.ICloner.Clone to an async variant called Serialization.ICloner.CloneAsync (**Breaking Change**).
- Removed Serialization.BinaryFormatterCloner due to reliance on deprecated BinaryFormatter (See https://aka.ms/binaryformatter for more information) (**Breaking Change**).
- Removed serializable attributes from all serializable classes as they are not used by any mainstream serializers (**Breaking Change**).
- Removed Serialization.SerializableExtensions due to reliance on deprecated BinaryFormatter (See https://aka.ms/binaryformatter for more information) (**Breaking Change**).

## End-User Impact

### BinaryFormatterCloner and SerializableExtensions

Both components where flagged as obsolette in release v3.0.0 of MooVC, with the recommendation to move away from the implementation due to the risks posed by the unsafe BinaryFormatter implementation. If you are still using these components and are unable to migrate to an alternative, it is recommended that you either:

A) Defer your upgrade to MooVC v5 until an alternative can be found.

or

B) Reimplement the unsafe components within your own core library.