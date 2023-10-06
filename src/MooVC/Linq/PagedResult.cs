namespace MooVC.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using MooVC.Collections.Generic;
using static MooVC.Linq.PagedResult_Resources;

/// <summary>
/// Represents the result of a request to page a sequence of type <see cref="T" />.
/// </summary>
/// <typeparam name="T">The type of the elements paged.</typeparam>
public sealed class PagedResult<T>
    : IReadOnlyList<T>
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
        : this(request, () => 0, () => Array.Empty<T>())
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
        Request = Guard.Against.Null(request, parameterName: nameof(request), message: PagedResultRequestRequired);
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
    public T this[int index] => values.ElementAt(index);

    /// <summary>
    /// Returns an enumerator that iterates through the elements in the result set.
    /// </summary>
    /// <returns>An enumerator for the elements in the result set.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return values.GetEnumerator();
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