namespace MooVC.Linq;

#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif
using static System.Math;

/// <summary>
/// Represents paging information used to control the amount of data returned from a sequence or query.
/// </summary>
public sealed class Paging
    : IEquatable<Paging>
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
    /// Initializes a new instance of the <see cref="Paging" /> class.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="size">The number of items per page.</param>
#if NET6_0_OR_GREATER
    [JsonConstructor]
#endif
    public Paging(ushort page = FirstPage, ushort size = DefaultSize)
    {
        Page = Max(page, FirstPage);
        Size = Max(size, MinimumSize);
    }

    /// <summary>
    /// Gets the default <see cref="Paging" /> instance.
    /// </summary>
    /// <value>
    /// The default <see cref="Paging" /> instance, which uses the <see cref="FirstPage" /> and <see cref="DefaultSize" /> values.
    /// </value>
    public static Paging Default { get; } = new();

    /// <summary>
    /// Gets the <see cref="Paging" /> instance that indicates that no paging be applied.
    /// </summary>
    /// <value>
    /// The <see cref="Paging" /> instance that indicates that no paging be applied.
    /// </value>
    public static Paging None { get; } = new(size: ushort.MaxValue);

    /// <summary>
    /// Gets the <see cref="Paging" /> instance that indicates that only one value be returned from the top of the sequence.
    /// </summary>
    /// <value>
    /// The <see cref="Paging" /> instance that indicates that only one value be returned from the top of the sequence.
    /// </value>
    public static Paging One { get; } = new(size: 1);

    /// <summary>
    /// Gets a value indicating whether this instance is the default instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the default instance; otherwise, <c>false</c>.
    /// </value>
#if NET6_0_OR_GREATER
    [JsonIgnore]
#endif
    public bool IsDefault => this == Default;

    /// <summary>
    /// Gets a value indicating whether this instance is the none instance.
    /// </summary>
    /// <value>
    /// <c>true</c> if the instance is the none instance; otherwise, <c>false</c>.
    /// </value>
#if NET6_0_OR_GREATER
    [JsonIgnore]
#endif
    public bool IsNone => this == None;

    /// <summary>
    /// Gets the requested page number, starting from <see cref="FirstPage" />.
    /// </summary>
    /// <value>
    /// The requested page number.
    /// </value>
    public ushort Page { get; }

    /// <summary>
    /// Gets the size associated with a page.
    /// </summary>
    /// <value>
    /// The size associated with a page.
    /// </value>
    public ushort Size { get; }

    /// <summary>
    /// Gets the number of entries in the sequence to be skipped to read the beginning of the desired page.
    /// </summary>
    /// <value>
    /// The number of entries in the sequence to be skipped to read the beginning of the desired page.
    /// </value>
#if NET6_0_OR_GREATER
    [JsonIgnore]
#endif
    public int Skip => (Page - FirstPage) * Size;

    /// <summary>
    /// Implicitly converts a <see cref="ushort" /> value to a <see cref="Paging" /> instance that requests the first page of a sequence with
    /// a <see cref="Size" /> matching the value specified or <see cref="MinimumSize" /> if a zero value is provided.
    /// </summary>
    /// <param name="size">The size associated with a page.</param>
    /// <returns>A new <see cref="Paging" /> instance that requests the first page of a sequence sized at the value specified.</returns>
    public static implicit operator Paging(ushort size)
    {
        return (FirstPage, size);
    }

    /// <summary>
    /// Implicitly converts a tuple of <see cref="ushort" /> values to a <see cref="Paging" /> instance.
    /// </summary>
    /// <param name="paging">A tuple containing the page number and number of items per page.</param>
    /// <returns>A new <see cref="Paging" /> instance with the specified page number and number of items per page.</returns>
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
    /// Determines whether two specified instances of <see cref="Paging"/> are equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, false.</returns>
    public static bool operator ==(Paging? left, Paging? right)
    {
        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two specified instances of <see cref="Paging"/> are not equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, false.</returns>

    public static bool operator !=(Paging? left, Paging? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Deconstructs the <see cref="Paging"/> instance into its page and size components.
    /// </summary>
    /// <param name="page">The page number of the paging.</param>
    /// <param name="size">The size of the paging.</param>
    public void Deconstruct(out ushort page, out ushort size)
    {
        page = Page;
        size = Size;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="Paging"/> instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    /// <remarks>
    /// This method overrides <see cref="object.Equals(object)"/> to provide a way to compare two <see cref="Paging"/> instances.
    /// </remarks>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Paging);
    }

    /// <summary>
    /// Indicates whether the current <see cref="Paging"/> instance is equal to another <see cref="Paging"/> instance.
    /// </summary>
    /// <param name="other">An instance of <see cref="Paging"/> to compare with this instance.</param>
    /// <returns>true if the current instance is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
    /// <remarks>
    /// This method implements the <see cref="IEquatable{T}"/> interface and provides a type-safe way to compare two <see cref="Paging"/> instances.
    /// Equality is based on the values of the <see cref="Page"/> and <see cref="Size"/> properties.
    /// </remarks>
    public bool Equals(Paging? other)
    {
        return other is not null && (ReferenceEquals(this, other) || (Page == other.Page && Size == other.Size));
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current <see cref="Paging"/> instance.</returns>
    /// <remarks>
    /// The hash code is calculated based on the values of the <see cref="Page"/> and <see cref="Size"/> properties.
    /// This implementation is suitable for use in hashing algorithms and data structures like a hash table.
    /// </remarks>
    public override int GetHashCode()
    {
#if NET6_0_OR_GREATER
        return HashCode.Combine(Page, Size);
#else
        unchecked
        {
            int hash = 17;

            hash = (hash * 23) + Page.GetHashCode();
            hash = (hash * 23) + Size.GetHashCode();

            return hash;
        }
#endif
    }

    /// <summary>
    /// Returns a new <see cref="Paging" /> instance representing the next page in the sequence or query.
    /// </summary>
    /// <returns>
    /// A new <see cref="Paging" /> instance representing the next page in the sequence or query.
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
    /// Returns a new <see cref="Paging" /> instance representing the previous page in the sequence or query.
    /// </summary>
    /// <returns>
    /// A new <see cref="Paging" /> instance representing the previous page in the sequence or query.
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