#if NET6_0_OR_GREATER
namespace MooVC.Paging;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using MooVC.Linq;
using MooVC.Paging.Serialization;

/// <summary>
/// Represents the result of a request to page a sequence of type <see cref="T" />.
/// </summary>
/// <typeparam name="T">The type of the elements paged.</typeparam>
[JsonConverter(typeof(PageConverter))]
public sealed record Page<T>
    : IReadOnlyList<T>
{
    private readonly T[] _values;

    /// <summary>
    /// Initializes a new instance of the <see cref="Page{T}" /> class with the values paged from the sequence.
    /// </summary>
    /// <param name="directive">The request that was used to page the sequence.</param>
    /// <param name="values">The paged sequence of elements.</param>
    /// <param name="total">The total number of elements in the sequence (if known).</param>
    public Page(Directive directive, IReadOnlyList<T> values, ulong? total = default)
    {
        Directive = directive;
        Total = total;
        _values = values.ToArrayOrEmpty();
    }

    /// <summary>
    /// Gets the number of elements in this result.
    /// </summary>
    /// <value>
    /// The number of elements in this result.
    /// </value>
    public int Count => _values.Length;

    /// <summary>
    /// Gets the request that was used to generate this result.
    /// </summary>
    /// <value>
    /// The request that was used to generate this result.
    /// </value>
    public Directive Directive { get; }

    /// <summary>
    /// Gets a value indicating whether this result has a known total for the number of elements.
    /// </summary>
    /// <value>
    /// <c>true</c> if the total is known; otherwise, <c>false</c>.
    /// </value>
    [MemberNotNullWhen(true, nameof(Total))]
    public bool HasTotal => Total.HasValue;

    /// <summary>
    /// Gets the total number of elements in the sequence.
    /// </summary>
    /// <value>
    /// The total number of elements in the sequence.
    /// </value>
    public ulong? Total { get; }

    /// <summary>
    /// Gets the element at the specified index in the result set.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get.</param>
    /// <returns>The element at the specified index in the result set.</returns>
    /// <exception cref="IndexOutOfRangeException">
    /// <paramref name="index" /> is outside the bounds of the sequence.
    /// </exception>
    public T this[int index] => _values[index];

    /// <summary>
    /// Deconstructs the <see cref="Page{T}" /> into its constituent parts.
    /// </summary>
    /// <param name="directive">The request that was used to generate this result.</param>
    /// <param name="total">The total number of elements in the sequence (if known).</param>
    /// <param name="values">The paged sequence of elements.</param>
    public void Deconstruct(out Directive directive, out ulong? total, out IReadOnlyList<T> values)
    {
        directive = Directive;
        total = Total;
        values = _values;
    }

    /// <summary>
    /// Returns the <see cref="Directive"/> required to retrieve the next page in the sequence.
    /// </summary>
    /// <returns>
    /// The <see cref="Directive"/> required to retrieve the next page in the sequence.
    /// </returns>
    public Directive Next()
    {
        return Directive + 1;
    }

    /// <summary>
    /// Returns the <see cref="Directive"/> required to retrieve the next page in the sequence.
    /// </summary>
    /// <returns>
    /// The <see cref="Directive"/> required to retrieve the next page in the sequence.
    /// </returns>
    public Directive Previous()
    {
        return Directive - 1;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the elements in the result set.
    /// </summary>
    /// <returns>
    /// An enumerator for the elements in the result set.
    /// </returns>
    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_values).GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the elements in the result set.
    /// </summary>
    /// <returns>
    /// An enumerator for the elements in the result set.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _values.GetEnumerator();
    }
}
#endif