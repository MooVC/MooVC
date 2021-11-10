# moovc

![Nuget](https://img.shields.io/nuget/v/moovc?style=plastic)![Nuget](https://img.shields.io/nuget/dt/moovc?style=plastic)![Azure DevOps builds](https://img.shields.io/azure-devops/build/vmartinspaul/MooVC/2?style=plastic)![Azure DevOps tests](https://img.shields.io/azure-devops/tests/vmartinspaul/MooVC/2?style=plastic)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

# Release v6.0.0

## Enhancements

- Added a Ensure.ArgumentInRange to simplify guard conditions where two comparable value types must be within a given inclusive range.
- Added a Ensure.ArgumentNotEmpty to simplify guard conditions where an enumerable must contain at least one element.
- Added a Ensure.ArgumentNotEmpty to simplify guard conditions where a Guid must not be equal to Guid.Empty.
- Added a Ensure.ArgumentNotEmpty to simplify guard conditions where a TimeSpan must be greater than TimeSpan.Zero.
- Added a Serialization.SerializationInfoEnumeratorExtensions.ToDictionary extension to produce a dictionary containing the elements stored within a SerializationInfo object.
- Added a Serialization.SerializationInfoExtensions.ToDictionary extension to produce a dictionary containing the elements stored within a SerializationInfo object.
- Changed Collections.Generic.EnumerableExtensions.ProcessAll so that it guarentees that the results will be returned based on the order received.
- Changed Collections.Generic.EnumerableExtensions.ProcessAllAsync so that it guarentees that the results will be returned based on the order received.
- Changed Ensure.ArgumentIsAcceptable so that it now returns the tested value.
- Changed Ensure.ArgumentIsAcceptable so that it now differentiates between references and structs (**breaking change**).
- Changed Ensure.ArgumentNotNull so that it now returns the tested value.
- Changed Ensure.ArgumentNotNull so that it now differentiates between references and structs.
- Changed Ensure.ArgumentNotNullOrWhiteSpace so that it now returns the tested value.

## End-User Impact

### ArgumentIsAcceptable

ArgumentIsAcceptable and ArgumentNotNull now return the value it tested to facilitate consistency with the new ArgumentNotEmpty and ArgumentInRange variants.  The intention is to utilize these methods as part of the setters on constructors.  The challenge arises in the return type, which is intended to be non-null when a nullable has been provided.  Value types retain nullability if the method fails to differentiate between values and references.  The breaking change arises as a result of differentiation.  If you supply a non-null value type, the build fails because it is unable to resolve to the correct overload of the method. The explicit type must be specifed to prevent the failure.