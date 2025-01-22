#if NET6_0_OR_GREATER
namespace MooVC.Paging;

using System.Text.Json.Serialization;
using static System.Math;

/// <summary>
/// Represents a directive to apply paging to a query.
/// </summary>
public readonly record struct Directive
{
    /// <summary>
    /// The default number of items per page.
    /// </summary>
    public const ushort DefaultSize = 10;

    /// <summary>
    /// The index assigned to the first page of a sequence.
    /// </summary>
    public const ushort FirstPage = 1;

    /// <summary>
    /// The minimum number of items per page.
    /// </summary>
    public const ushort MinimumSize = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Directive" /> struct.
    /// </summary>
    /// <param name="page">
    /// The page number to retrieve.
    /// </param>
    /// <param name="size">
    /// The number of items per page.
    /// </param>
    [JsonConstructor]
    public Directive(ushort page = FirstPage, ushort size = DefaultSize)
    {
        Page = Max(page, FirstPage);
        Size = Max(size, MinimumSize);
    }

    /// <summary>
    /// Gets the <see cref="Directive" /> instance that indicates that no paging be applied (i.e. return all).
    /// </summary>
    /// <value>
    /// The <see cref="Directive" /> instance that indicates that no paging be applied (i.e. return all).
    /// </value>
    public static Directive All { get; } = new(size: ushort.MaxValue);

    /// <summary>
    /// Gets a value indicating whether this instance is the <see cref="All"/> instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the <see cref="All"/> instance; otherwise, <c>false</c>.
    /// </value>
    [JsonIgnore]
    public bool IsAll => this == All;

    /// <summary>
    /// Gets a value indicating whether this instance is the default instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the default instance; otherwise, <c>false</c>.
    /// </value>
    [JsonIgnore]
    public bool IsDefault => this == default;

    /// <summary>
    /// Gets the requested page number, starting from <see cref="FirstPage" />.
    /// </summary>
    /// <value>
    /// The requested page number.
    /// </value>
    public ushort Page { get; } = FirstPage;

    /// <summary>
    /// Gets the size associated with a page.
    /// </summary>
    /// <value>
    /// The size associated with a page.
    /// </value>
    public ushort Size { get; } = DefaultSize;

    /// <summary>
    /// Gets the number of entries in the sequence to be skipped to read the beginning of the desired page.
    /// </summary>
    /// <value>
    /// The number of entries in the sequence to be skipped to read the beginning of the desired page.
    /// </value>
    [JsonIgnore]
    public int Skip => (Page - FirstPage) * Size;

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
        return new(page, DefaultSize);
    }

    /// <summary>
    /// Implicitly converts a tuple of <see cref="ushort" /> values to a <see cref="Directive" /> instance.
    /// </summary>
    /// <param name="directive">
    /// A tuple containing the page number and number of items per page.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive" /> instance with the specified page number and number of items per page.
    /// </returns>
    public static implicit operator Directive((ushort Page, ushort Size) directive)
    {
        return new Directive(page: directive.Page, size: directive.Size);
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
    /// with the same <see cref="Size"/> as the original <paramref name="directive"/>.
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

        return new Directive(page: page, size: directive.Size);
    }

    /// <summary>
    /// Increments the <see cref="Page"/> number by one.
    /// </summary>
    /// <param name="directive">
    /// The <see cref="Directive"/> to increment.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive"/> with the <see cref="Page"/> incremented by one, with the same <see cref="Size"/> as the original <paramref name="directive"/>.
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
    /// with the same <see cref="Size"/> as the original <paramref name="directive"/>.
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

        return new Directive(page: page, size: directive.Size);
    }

    /// <summary>
    /// Decrements the <see cref="Page"/> number by one.
    /// </summary>
    /// <param name="directive">
    /// The <see cref="Directive"/> to decrement.
    /// </param>
    /// <returns>
    /// A new <see cref="Directive"/> with the <see cref="Page"/> decremented by one, with the same <see cref="Size"/> as the original <paramref name="directive"/>.
    /// </returns>
    /// <remarks>
    /// If the page number has already reached <see cref="FirstPage"/>, then the same <paramref name="directive"/> is returned.
    /// </remarks>
    public static Directive operator --(Directive directive)
    {
        return directive - 1;
    }

    /// <summary>
    /// Deconstructs the type, returning the <see cref="Page"/> and <see cref="Size"/>.
    /// </summary>
    /// <param name="page">
    /// The value associated with <see cref="Page"/>.
    /// </param>
    /// <param name="size">
    /// The value associated with <see cref="Size"/>.
    /// </param>
    public void Deconstruct(out ushort page, out ushort size)
    {
        page = Page;
        size = Size;
    }
}
#endif