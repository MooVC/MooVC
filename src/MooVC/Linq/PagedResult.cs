namespace MooVC.Linq;

using System.Collections;
#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
using MooVC.Linq.Serialization;
#endif
using Ardalis.GuardClauses;
using static MooVC.Linq.PagedResult_Resources;

/// <summary>
/// Represents the result of a request to page a sequence of type <see cref="T" />.
/// </summary>
/// <typeparam name="T">The type of the elements paged.</typeparam>
#if NET6_0_OR_GREATER
[JsonConverter(typeof(PagedResultConverter))]
#endif
public sealed class PagedResult<T>
    : IReadOnlyList<T>,
      IEquatable<PagedResult<T>>
{
    private readonly IReadOnlyList<T> values;

    /// <summary>
    /// Initializes a new, empty instance, of the <see cref="PagedResult{T}" /> class.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request" /> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request)
        : this(request, () => 0, () => [])
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request" /> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, IEnumerable<T> values)
        : this(request, () => (ulong)values.LongCount(), values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">The total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request" /> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, int total, IEnumerable<T> values)
        : this(request, () => (ulong)total, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">The total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request" /> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, long total, IEnumerable<T> values)
        : this(request, () => (ulong)total, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class with the values paged from the sequence.
    /// </summary>
    /// <param name="request">The request that was used to page the sequence.</param>
    /// <param name="total">The total number of elements in the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request" /> is <see langword="null" />.
    /// </exception>
    public PagedResult(Paging request, ulong total, IEnumerable<T> values)
        : this(request, () => total, values)
    {
    }

    private PagedResult(Paging request, Func<ulong> total, IEnumerable<T> values)
        : this(request, total, () => values.ToArrayOrEmpty())
    {
    }

    private PagedResult(Paging request, Func<ulong> total, Func<IReadOnlyList<T>> values)
    {
        Request = Guard.Against.Null(request, message: RequestRequired);
        Total = total();
        this.values = values();
    }

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
    /// Gets the number of elements in this result.
    /// </summary>
    /// <value>
    /// The number of elements in this result.
    /// </value>
    public int Count => values.Count;

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
    /// Gets the element at the specified index in the result set.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get.</param>
    /// <returns>The element at the specified index in the result set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index" /> is outside the bounds of the sequence.
    /// </exception>
    public T this[int index] => values[index];

    /// <summary>
    /// Determines whether two specified instances of <see cref="PagedResult{T}"/> are equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, false.</returns>
    public static bool operator ==(PagedResult<T>? left, PagedResult<T>? right)
    {
        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two specified instances of <see cref="PagedResult{T}"/> are not equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, false.</returns>
    public static bool operator !=(PagedResult<T>? left, PagedResult<T>? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="PagedResult{T}"/> instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    /// <remarks>
    /// This method overrides <see cref="object.Equals(object)"/> to provide a way to compare two <see cref="PagedResult{T}"/> instances.
    /// </remarks>
    public override bool Equals(object? obj)
    {
        return Equals(obj as PagedResult<T>);
    }

    /// <summary>
    /// Indicates whether the current <see cref="PagedResult{T}"/> instance is equal to another <see cref="PagedResult{T}"/> instance.
    /// </summary>
    /// <param name="other">An instance of <see cref="PagedResult{T}"/> to compare with this instance.</param>
    /// <returns>true if the current instance is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
    /// <remarks>
    /// This method implements the <see cref="IEquatable{T}"/> interface and provides a type-safe way to compare two <see cref="PagedResult{T}"/> instances.
    /// </remarks>
    public bool Equals(PagedResult<T>? other)
    {
        return other is not null
            && (ReferenceEquals(this, other) || (Request.Equals(other.Request) && Total == other.Total && values.SequenceEqual(other.values)));
    }

    /// <summary>
    /// Returns an enumerator that iterates through the elements in the result set.
    /// </summary>
    /// <returns>An enumerator for the elements in the result set.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return values.GetEnumerator();
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current <see cref="PagedResult{T}"/> instance.</returns>
    /// <remarks>
    /// The hash code is calculated based on the values, including the <see cref="Request"/> and <see cref="Total"/> properties.
    /// This implementation is suitable for use in hashing algorithms and data structures like a hash table.
    /// </remarks>
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = Request.GetHashCode();

            hashCode = (hashCode * 397) ^ Total.GetHashCode();

            foreach (T element in values)
            {
                hashCode = (hashCode * 397) ^ (element?.GetHashCode() ?? 0);
            }

            return hashCode;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the elements in the result set.
    /// </summary>
    /// <returns>An enumerator for the elements in the result set.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return values.GetEnumerator();
    }
}