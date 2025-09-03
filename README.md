# MooVC [![NuGet](https://img.shields.io/nuget/v/MooVC?logo=nuget)](https://www.nuget.org/packages/MooVC/) [![GitHub](https://img.shields.io/github/license/MooVC/MooVC)](LICENSE.md)

The MooVC library contains a collection of functionalities common to many applications, gathered to support the rapid development of a wide variety of applications targeting multiple platforms.

MooVC was originally created as a PHP based framework back in 2009, intended to support the rapid development of object-oriented web applications based on the Model-View-Controller design pattern that were to be rendered in well-formed XHTML.  It is from this that MooVC gets its name - the **M**odel-**o**bject-**o**riented-**V**iew-**C**ontroller.

While the original MooVC PHP based framework has long since been deprecated, many of the lessons learned from it have formed the basis of solutions the author has since developed.  This library, and those related to it, are all intended to support the rapid development of high quality software that addresses a variety of use-cases.


## Getting Started

Install the core package:

```bash
dotnet add package MooVC
```

Add optional infrastructure packages as needed; each capability below lists extensions that provide additional implementations.

## Capabilities

MooVC packages a set of reusable building blocks.

### Compression

Compression enhances your code by shrinking payloads and eliminating boilerplate through the `ICompressor` abstraction with built-in Brotli, GZip, and Deflate implementations.

#### Usage
Compress or decompress streams and byte arrays with a single call.

```csharp
ICompressor compressionProvider = new GZipCompressor();
IEnumerable<byte> compressedData = await compressionProvider.Compress(originalData, CancellationToken.None);
IEnumerable<byte> restoredData = await compressionProvider.Decompress(compressedData, CancellationToken.None);
```

#### Infrastructure Options

* `MooVC.Infrastructure.Compression.LZ4` – LZ4 compressor implementation for high throughput scenarios

### Serialization and Cloning

Serialization and cloning streamline the persistence and duplication of complex objects through consistent `ISerializer` and `ICloner` interfaces. The core library includes a System.Text.Json implementation and supports optional compression.

#### Usage
Serialize or deserialize objects and create deep clones with a single call.

```csharp
var jsonSerializer = new MooVC.Serialization.Json.Serializer();
IEnumerable<byte> serializedOrder = await jsonSerializer.Serialize(purchaseOrder, CancellationToken.None);
Order clonedOrder = await jsonSerializer.Deserialize<Order>(serializedOrder, CancellationToken.None);
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
Directive pagingRequest = new(limit: 25, page: 1);
Page<Customer> customerPage = customerQuery.ToPage(pagingRequest);
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### Threading and Hosting

Threading and hosting helpers coordinate asynchronous initialization and exclusive access to shared resources, reducing concurrency errors.

Helpers include:

* `Initializer<T>` for asynchronous lazy initialization
* `Coordinator<T>` for mutual exclusion by context
* `ThreadSafeHostedService` to safely start and stop multiple hosted services

#### Usage

```csharp
var configInitializer = new Initializer<Configuration>(_ => LoadConfigAsync());
Configuration configuration = await configInitializer.Initialize(CancellationToken.None);

var orderCoordinator = new Coordinator<string>();
using IContext<string> orderContext = await orderCoordinator.Apply("orders", CancellationToken.None);
// exclusive work
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### LINQ and Collection Extensions

LINQ and collection extensions keep queries expressive and succinct:

* `WhereIf` enhances your code by allowing conditional application of filters using LINQ.
* `ForAll` enhances your code by performing parallel operations across sequences.
* `Combine` enhances your code by merging two sequences into tuples.
* `ToIndex` enhances your code by creating lookups keyed by a selector.
* `AddRange` and `Replace` enhance your code by extending `ICollection` without loops.

#### Usage

```csharp
IDictionary<Guid, Order> orderLookup = allOrders.ToIndex(currentOrder => currentOrder.Id);

IEnumerable<Order> activeOrders = allOrders.WhereIf(includeOnlyActive, currentOrder => currentOrder.IsActive);

await activeOrders.ForAll(async currentOrder => await ProcessOrderAsync(currentOrder));
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

### Dynamic and I/O Helpers

Dynamic and I/O helpers reduce repetitive plumbing when working with dynamic objects, exceptions, and streams.

#### Usage
Utilities for cloning `ExpandoObject`, navigating exception trees, working with streams, and more.

```csharp
dynamic clonedObject = originalObject.Clone();
```

#### Infrastructure Options
Provided in the core library; no additional packages required.

These features can be adopted piecemeal – pick the utilities that help your project and ignore the rest.

## Why Use MooVC?

* **Accelerated Development** – Reuse battle tested helpers instead of re‑implementing common infrastructure.
* **Consistency** – Uniform APIs for serialization, compression, and coordination keep code bases consistent across projects.
* **Productivity** – Extension methods and abstractions simplify code, letting software engineers focus on business logic.

Contributions and feedback are welcome.
