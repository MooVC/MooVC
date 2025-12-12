#if NET6_0_OR_GREATER
namespace MooVC.Paging;

using System.Text.Json.Serialization;
using static System.Math;

/// <summary>
/// Represents a directive to apply paging to a query.
/// </summary>
/// <param name="Limit">
/// The maximum number of items to return per page.
/// </param>
/// <param name="Page">
/// The requested page number, starting from <see cref="FirstPage" />.
/// </param>
public readonly record struct Directive(ushort Limit = Directive.DefaultLimit, ushort Page = Directive.FirstPage)
{
    /// <summary>
    /// The default maximum number of items to return per page.
    /// </summary>
    public const ushort DefaultLimit = 10;

    /// <summary>
    /// The index assigned to the first page of a sequence.
    /// </summary>
    public const ushort FirstPage = 0;

    /// <summary>
    /// The minimum restriction to place upon the number of items per page.
    /// </summary>
    public const ushort MinimumLimit = 0;

    /// <summary>
    /// Gets the <see cref="Directive" /> instance that indicates that no paging be applied (i.e. return all).
    /// </summary>
    /// <value>
    /// The <see cref="Directive" /> instance that indicates that no paging be applied (i.e. return all).
    /// </value>
    public static Directive All { get; }

    /// <summary>
    /// Gets a value indicating whether this instance is the <see cref="All"/> instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the <see cref="All"/> instance; otherwise, <c>false</c>.
    /// </value>
    [JsonIgnore]
    public bool IsAll => this == All;

    /// <summary>
    /// Gets the number of entries in the sequence to be skipped to read the beginning of the desired page.
    /// </summary>
    /// <value>
    /// The number of entries in the sequence to be skipped to read the beginning of the desired page.
    /// </value>
    [JsonIgnore]
    public int Skip => (Page - FirstPage) * Limit;

    /// <summary>
    /// Gets the number of entries in the sequence to return for the desired page.
    /// </summary>
    /// <value>
    /// The number of entries in the sequence to return for the desired page.
    /// </value>
    [JsonIgnore]
    public int Take => Limit == All.Limit
        ? int.MaxValue
        : Limit;

    /// <summary>
    /// Implicitly converts a <see cref="ushort" /> value to a <see cref="Directive" /> instance that requests the first page of a sequence with
    /// a <see cref="Page" /> matching the value specified or <see cref="FirstPage" /> if a zero value is provided.
    /// </summary>
    /// <param name="page">
    /// The size associated with a page.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive" /> instance that requests the first page of a sequence sized at the value specified.
    /// </returns>
    public static implicit operator Directive(ushort page)
    {
        return new(Page: page);
    }

    /// <summary>
    /// Adds the specified number to the <see cref="Page"/> number.
    /// </summary>
    /// <param name="directive">
    /// The <see cref="Directive"/> to increment.
    /// </param>
    /// <param name="increment">
    /// The number to add to the <see cref="Page"/>.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive"/> with the <see cref="Page"/> incremented by the specified number,
    /// with the same <see cref="Limit"/> as the original <paramref name="directive"/>.
    /// </returns>
    /// <remarks>
    /// If the page number has already reached <see cref="ushort.MaxValue"/>, then the same <paramref name="directive"/> is returned.
    /// </remarks>
    public static Directive operator +(Directive directive, int increment)
    {
        if (directive.Page == ushort.MaxValue)
        {
            return directive;
        }

        ushort page = (ushort)(directive.Page + increment);

        return directive with
        {
            Page = page,
        };
    }

    /// <summary>
    /// Increments the <see cref="Page"/> number by one.
    /// </summary>
    /// <param name="directive">
    /// The <see cref="Directive"/> to increment.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive"/> with the <see cref="Page"/> incremented by one, with the same <see cref="Limit"/> as the original <paramref name="directive"/>.
    /// </returns>
    /// <remarks>
    /// If the page number has already reached <see cref="ushort.MaxValue"/>, then the same <paramref name="directive"/> is returned.
    /// </remarks>
    public static Directive operator ++(Directive directive)
    {
        return directive + 1;
    }

    /// <summary>
    /// Subtracts the specified number to the <see cref="Page"/> number.
    /// </summary>
    /// <param name="directive">
    /// The <see cref="Directive"/> to decrement.
    /// </param>
    /// <param name="decrement">
    /// The number to subtract from the <see cref="Page"/>.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive"/> with the <see cref="Page"/> decremented by the specified number,
    /// with the same <see cref="Limit"/> as the original <paramref name="directive"/>.
    /// </returns>
    /// <remarks>
    /// If the page number has already reached <see cref="FirstPage"/>, then the same <paramref name="directive"/> is returned.
    /// </remarks>
    public static Directive operator -(Directive directive, int decrement)
    {
        if (directive.Page == FirstPage)
        {
            return directive;
        }

        ushort page = (ushort)(directive.Page - decrement);

        return directive with
        {
            Page = page,
        };
    }

    /// <summary>
    /// Decrements the <see cref="Page"/> number by one.
    /// </summary>
    /// <param name="directive">
    /// The <see cref="Directive"/> to decrement.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive"/> with the <see cref="Page"/> decremented by one, with the same <see cref="Limit"/> as the original <paramref name="directive"/>.
    /// </returns>
    /// <remarks>
    /// If the page number has already reached <see cref="FirstPage"/>, then the same <paramref name="directive"/> is returned.
    /// </remarks>
    public static Directive operator --(Directive directive)
    {
        return directive - 1;
    }
}
#endif