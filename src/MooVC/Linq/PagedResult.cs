namespace MooVC.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MooVC.Collections.Generic;
using MooVC.Serialization;
using static MooVC.Ensure;
using static MooVC.Linq.Resources;

/// <summary>
/// Represents the result of a request to page a sequence of type <see cref="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements paged.</typeparam>
[Serializable]
public sealed class PagedResult<T>
    : ISerializable
{
    private readonly Lazy<ulong> count;

    /// <summary>
    /// Initializes a new, empty instance, of the <see cref="PagedResult{T}"/> class.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request)
        : this(request, () => 0, Enumerable.Empty<T>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, IEnumerable<T> values)
        : this(request, () => (ulong)values.LongCount(), values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">The total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, int total, IEnumerable<T> values)
        : this(request, () => (ulong)total, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">The total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, long total, IEnumerable<T> values)
        : this(request, () => (ulong)total, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">The total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, ulong total, IEnumerable<T> values)
        : this(request, () => total, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">A function that provides the total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is <see langword="null" />.
    /// </exception>
    private PagedResult(Paging request, Func<ulong> total, IEnumerable<T> values)
    {
        Request = IsNotNull(request, argumentName: nameof(request), message: PagedResultRequestRequired);
        Total = total();
        Values = values.Snapshot();

        count = new(CalculateCount);
    }

    /// <summary>
    /// Supports deserialization of an instance of the <see cref="PagedResult{T}"/> class
    /// via the specified <paramref name="info"/> and <paramref name="context"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that holds the serialized object data relating to the instance.</param>
    /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information about the stream.</param>
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    private PagedResult(SerializationInfo info, StreamingContext context)
    {
        Request = info.TryGetValue(nameof(Request), defaultValue: Paging.Default)!;
        Total = info.TryGetValue<ulong>(nameof(Total));
        Values = info.TryGetEnumerable<T>(nameof(Values));

        count = new(CalculateCount);
    }

    /// <summary>
    /// Gets the number of elements in this result.
    /// </summary>
    /// <value>
    /// The number of elements in this result.
    /// </value>
    public ulong Count => count.Value;

    /// <summary>
    /// Gets a value indicating whether this result has any elements.
    /// </summary>
    /// <value>
    /// <c>true</c> if there are any results; otherwise, <c>false</c>.
    /// </value>
    public bool HasResults => Count > 0;

    /// <summary>
    /// Gets a value indicating whether this result has no elements.
    /// </summary>
    /// <value>
    /// <c>true</c> if there are no results; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Gets the request that was used to generate this result.
    /// </summary>
    /// <value>
    /// The request that was used to generate this result.
    /// </value>
    public Paging Request { get; }

    /// <summary>
    /// Gets the total number of elements in the sequence.
    /// </summary>
    /// <value>
    /// The total number of elements in the sequence.
    /// </value>
    public ulong Total { get; }

    /// <summary>
    /// Gets the paged sequence of elements.
    /// </summary>
    /// <value>
    /// The paged sequence of elements.
    /// </value>
    public IEnumerable<T> Values { get; }

    /// <summary>
    /// Gets the element at the specified index in the result set.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get.</param>
    /// <returns>The element at the specified index in the result set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index" /> is outside the bounds of the <paramref name="Values" /> sequence.
    /// </exception>
    public T this[int index] => Values.ElementAt(index);

    /// <summary>
    /// Implicitly converts the specified <paramref name="result"/> to an array of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>An array of <typeparamref name="T"/>.</returns>
    public static implicit operator T[](PagedResult<T>? result)
    {
        if (result is null)
        {
            return Array.Empty<T>();
        }

        return result.Values.ToArray();
    }

    /// <summary>
    /// Implicitly converts the specified <paramref name="result"/> to a ulong representing the <paramref name="Count"/> of elements returned.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>The count of elements stored within the <paramref name="result"/>.</returns>
    public static implicit operator ulong(PagedResult<T>? result)
    {
        if (result is null)
        {
            return 0ul;
        }

        return result.Count;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the elements in the result set.
    /// </summary>
    /// <returns>An enumerator for the elements in the result set.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="PagedResult{T}"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddValue(nameof(Request), Request, defaultValue: Paging.Default);
        _ = info.TryAddValue(nameof(Total), Total);
        _ = info.TryAddEnumerable(nameof(Values), Values);
    }

    private ulong CalculateCount()
    {
        return (ulong)Values.LongCount();
    }
}