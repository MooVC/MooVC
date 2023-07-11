namespace MooVC.Linq;

using System;
using static System.Math;

/// <summary>
/// Represents paging information used to control the amount of data returned from a sequence or query.
/// </summary>
public sealed class Paging
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

    private static readonly Lazy<Paging> @default = new(() => new Paging());
    private static readonly Lazy<Paging> none = new(() => new Paging(size: ushort.MaxValue));
    private static readonly Lazy<Paging> one = new(() => new Paging(size: 1));

    /// <summary>
    /// Initializes a new instance of the <see cref="Paging"/> class.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="size">The number of items per page.</param>
    public Paging(ushort page = FirstPage, ushort size = DefaultSize)
    {
        Page = Max(page, FirstPage);
        Size = Max(size, MinimumSize);
    }

    /// <summary>
    /// Gets the default <see cref="Paging"/> instance.
    /// </summary>
    /// <value>
    /// The default <see cref="Paging"/> instance, which uses the <see cref="FirstPage"/> and <see cref="DefaultSize"/> values.
    /// </value>
    public static Paging Default => @default.Value;

    /// <summary>
    /// Gets the <see cref="Paging"/> instance that indicates that no paging be applied.
    /// </summary>
    /// <value>
    /// The <see cref="Paging"/> instance that indicates that no paging be applied.
    /// </value>
    public static Paging None => none.Value;

    /// <summary>
    /// Gets the <see cref="Paging"/> instance that indicates that only one value be returned from the top of the sequence.
    /// </summary>
    /// <value>
    /// The <see cref="Paging"/> instance that indicates that only one value be returned from the top of the sequence.
    /// </value>
    public static Paging One => one.Value;

    /// <summary>
    /// Gets a value indicating whether this instance is the default instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the default instance; otherwise, <c>false</c>.
    /// </value>
    public bool IsDefault => this == Default;

    /// <summary>
    /// Gets a value indicating whether this instance is the none instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the none instance; otherwise, <c>false</c>.
    /// </value>
    public bool IsNone => this == None;

    /// <summary>
    /// Gets the requested page number, starting from <see cref="FirstPage"/>.
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
    public int Skip => (Page - FirstPage) * Size;

    /// <summary>
    /// Implicitly converts a <see cref="ushort"/> value to a <see cref="Paging"/> instance that requests the first page of a sequence with
    /// a <see cref="Size"/> matching the value specified or <see cref="MinimumSize"/> if a zero value is provided.
    /// </summary>
    /// <param name="size">The size associated with a page.</param>
    /// <returns>A new <see cref="Paging"/> instance that requests the first page of a sequence sized at the value specified.</returns>
    public static implicit operator Paging(ushort size)
    {
        return (FirstPage, size);
    }

    /// <summary>
    /// Implicitly converts a tuple of <see cref="ushort"/> values to a <see cref="Paging"/> instance.
    /// </summary>
    /// <param name="paging">A tuple containing the page number and number of items per page.</param>
    /// <returns>A new <see cref="Paging"/> instance with the specified page number and number of items per page.</returns>
    public static implicit operator Paging((ushort Page, ushort Size) paging)
    {
        Paging? result = default;

        if (paging.Page == 1)
        {
            result = paging.Size switch
            {
                MinimumSize => One,
                DefaultSize => Default,
                ushort.MaxValue => None,
                _ => default,
            };
        }

        return result ?? new Paging(page: paging.Page, size: paging.Size);
    }

    /// <summary>
    /// Returns a new <see cref="Paging"/> instance representing the next page in the sequence or query.
    /// </summary>
    /// <returns>
    /// A new <see cref="Paging"/> instance representing the next page in the sequence or query.
    /// </returns>
    public Paging Next()
    {
        if (Page == ushort.MaxValue)
        {
            return this;
        }

        return new Paging(page: (ushort)(Page + 1), size: Size);
    }

    /// <summary>
    /// Returns a new <see cref="Paging"/> instance representing the previous page in the sequence or query.
    /// </summary>
    /// <returns>
    /// A new <see cref="Paging"/> instance representing the previous page in the sequence or query.
    /// </returns>
    public Paging Previous()
    {
        if (Page == FirstPage)
        {
            return this;
        }

        return new Paging(page: (ushort)(Page - 1), size: Size);
    }
}