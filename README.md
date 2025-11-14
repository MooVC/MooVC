# MooVC [![NuGet](https://img.shields.io/nuget/v/MooVC?logo=nuget)](https://www.nuget.org/packages/MooVC/) [![GitHub](https://img.shields.io/github/license/MooVC/MooVC)](LICENSE.md)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.

## Table of Contents
- [Getting Started](#getting-started)
- [Capabilities](#capabilities)
  - [Compression](#compression)
  - [Serialization and Cloning](#serialization-and-cloning)
  - [Paging](#paging)
  - [Threading](#threading)
  - [Hosting](#hosting)
  - [LINQ and Collection Extensions](#linq-and-collection-extensions)
  - [Dynamic and I/O Helpers](#dynamic-and-io-helpers)
- [Why Use MooVC?](#why-use-moovc)

## Getting Started

Install the core package:

```bash
dotnet add package MooVC
```

Add optional infrastructure packages as needed; each capability below lists extensions that provide additional implementations.

### Target Frameworks

MooVC libraries target .NET Standard 2.0, .NET 8.0, .NET 9.0, and .NET 10.0, ensuring compatibility across current and long-term supported platforms.

## Capabilities

MooVC packages a set of reusable building blocks.

### Compression

Compression enhances your code by shrinking payloads and eliminating boilerplate through the `ICompressor` abstraction with built-in Brotli, GZip, and Deflate implementations.

#### Usage
Compress or decompress streams and byte arrays with a single call.

```csharp
ICompressor provider = new GZipCompressor();
IEnumerable<byte> compressed = await provider.Compress(original, CancellationToken.None);
IEnumerable<byte> restored = await provider.Decompress(compressed, CancellationToken.None);
```

#### Infrastructure Options

* `MooVC.Infrastructure.Compression.LZ4` – LZ4 compressor implementation for high throughput scenarios

### Serialization and Cloning

Serialization and cloning streamline the persistence and duplication of complex objects through consistent `ISerializer` and `ICloner` interfaces. The core library includes a System.Text.Json implementation and supports optional compression.

#### Usage
Serialize or deserialize objects and create deep clones with a single call.

```csharp
var serializer = new MooVC.Serialization.Json.Serializer();
IEnumerable<byte> serializedOrder = await serializer.Serialize(purchaseOrder, CancellationToken.None);
Order clonedOrder = await serializer.Deserialize<Order>(serializedOrder, CancellationToken.None);
```

#### Infrastructure Options

* `MooVC.Infrastructure.Serialization.Json.Newtonsoft` – Newtonsoft.Json serializer
* `MooVC.Infrastructure.Serialization.MessagePack` – high performance binary serializer
* `MooVC.Infrastructure.Serialization.Bson.Newtonsoft` – BSON serializer
* `MooVC.Infrastructure.Serialization.Apex` – Apex binary serializer

### Paging

Paging slices large data sets into predictable chunks using `Directive` and `Page<T>` types, preventing timeouts and lowering memory usage.

#### Usage
Construct a directive and turn queries into pages.

```csharp
Directive request = new(limit: 25, page: 1);
Page<Customer> customerPage = customerQuery.ToPage(request);
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### Threading

Threading helpers coordinate asynchronous initialization and exclusive access to shared resources, reducing concurrency errors.

Helpers include:

* `Initializer<T>` for asynchronous lazy initialization
* `Coordinator<T>` for mutual exclusion by context

#### Usage

```csharp
var initializer = new Initializer<Configuration>(_ => LoadConfigAsync());
Configuration configuration = await initializer.Initialize(CancellationToken.None);

var coordinator = new Coordinator<string>();
using IContext<string> context = await coordinator.Apply("orders", CancellationToken.None);
// exclusive work
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### Hosting

Hosting helpers safely start and stop long-running services across threads.

Helpers include:

* `ThreadSafeHostedService` to coordinate multiple hosted services

#### Usage

```csharp
var service = new ThreadSafeHostedService(example, logger);
await service.StartAsync(CancellationToken.None);
// ...
await service.StopAsync(CancellationToken.None);
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### LINQ and Collection Extensions

LINQ and collection extensions keep queries expressive and succinct. Each extension below targets a common scenario and includes an API-style summary for quick reference.

#### WhereIf

Conditionally apply a predicate only when a supplied condition is met.

##### Signature

```csharp
public static IEnumerable<T>? WhereIf<T>(
    this IEnumerable<T>? enumeration,
    bool isApplicable,
    Func<T, bool> predicate)

public static IEnumerable<T>? WhereIf<T>(
    this IEnumerable<T>? enumeration,
    Func<bool> condition,
    Func<T, bool> predicate)
```

##### Parameters

* `enumeration` – The sequence to filter.
* `isApplicable` / `condition` – Determines whether the filter is applied.
* `predicate` – The condition used to filter items.

##### Returns

* The filtered sequence if the condition is satisfied; otherwise, the original sequence.

##### Example

```csharp
IEnumerable<Order> activeOrders = allOrders.WhereIf(
    includeOnlyActive,
    order => order.IsActive);
```

#### ForAll

Execute an action for every element in the sequence, synchronously or asynchronously.

##### Signature

```csharp
public static void ForAll<T>(this IEnumerable<T>? items, Action<T> action)

public static Task ForAll<T>(this IEnumerable<T>? items, Func<T, Task> operation)
```

##### Parameters

* `items` – The sequence of items to iterate.
* `action` / `operation` – The delegate executed for each item.

##### Returns

* A `Task` representing completion for the asynchronous overload; otherwise, nothing.

##### Example

```csharp
await activeOrders.ForAll(ProcessOrderAsync);
```

#### Combine

Append additional items to an existing sequence without creating temporary collections.

##### Signature

```csharp
public static IEnumerable<T> Combine<T>(this IEnumerable<T>? source, T instance)

public static IEnumerable<T> Combine<T>(this IEnumerable<T>? source, IEnumerable<T>? instances)
```

##### Parameters

* `source` – The original sequence.
* `instance` / `instances` – Items to append to the sequence.

##### Returns

* A sequence containing the original elements followed by the appended items.

##### Example

```csharp
IEnumerable<int> combined = existing.Combine(new[] { 4, 5 });
```

#### ToIndex

Create a dictionary keyed by values selected from each element.

##### Signature

```csharp
public static IDictionary<TSubject, TValue> ToIndex<TSubject, TValue>(
    this IEnumerable<TSubject>? source,
    Func<TSubject, TValue> selector)

public static IDictionary<TSubject, TTransform> ToIndex<TSubject, TTransform, TValue>(
    this IEnumerable<TSubject>? source,
    Func<TSubject, TValue> selector,
    Func<TValue, TTransform> transform)
```

##### Parameters

* `source` – The sequence to index.
* `selector` – Projects each element into a key.
* `transform` – Converts the selected value before insertion.

##### Returns

* A dictionary containing keys and values generated from the sequence.

##### Example

```csharp
IDictionary<Guid, Order> orderLookup = allOrders
    .ToIndex(order => order.Id);
```

#### AddRange

Insert multiple items into an `ICollection<T>` without manual loops.

##### Signature

```csharp
public static void AddRange<T>(this ICollection<T> target, IEnumerable<T>? items)
```

##### Parameters

* `target` – The collection receiving new items.
* `items` – The elements to add to the collection.

##### Returns

* Nothing. The `target` collection is updated in place.

##### Example

```csharp
ICollection<Order> pending = new List<Order>();
pending.AddRange(@new);
```

#### Replace

Clear an `ICollection<T>` and populate it with a replacement sequence.

##### Signature

```csharp
public static void Replace<T>(this ICollection<T> target, IEnumerable<T>? replacements)
```

##### Parameters

* `target` – The collection whose contents are to be replaced.
* `replacements` – The new elements for the collection.

##### Returns

* Nothing. The `target` collection is overwritten with `replacements`.

##### Example

```csharp
ICollection<Order> processed = GetExistingOrders();
processed.Replace(latest);
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### Dynamic and I/O Helpers

Dynamic and I/O helpers reduce repetitive plumbing when working with dynamic objects, exceptions, and streams.

#### Usage
Utilities for cloning `ExpandoObject`, navigating exception trees, working with streams, and more.

```csharp
dynamic cloned = original.Clone();
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

These features can be adopted piecemeal – pick the utilities that help your project and ignore the rest.

## Why Use MooVC?

* **Accelerated Development** – Reuse battle tested helpers instead of re‑implementing common infrastructure.
* **Consistency** – Uniform APIs for serialization, compression, and coordination keep code bases consistent across projects.
* **Productivity** – Extension methods and abstractions simplify code, letting software engineers focus on business logic.

Contributions and feedback are welcome.