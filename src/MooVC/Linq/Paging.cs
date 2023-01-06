namespace MooVC.Linq;

using System;
using System.Linq;
using System.Runtime.Serialization;
using MooVC.Serialization;
using static System.Math;

/// <summary>
/// Represents paging information used to control the amount of data returned from a sequence or query.
/// </summary>
[Serializable]
public class Paging
    : ISerializable
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
    /// Supports deserialization of an instance of the <see cref="Paging"/> class
    /// via the specified <paramref name="info"/> and <paramref name="context"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that holds the serialized object data relating to the instance.</param>
    /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information about the stream.</param>
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    protected Paging(SerializationInfo info, StreamingContext context)
    {
        Page = info.GetValue<ushort>(nameof(Page));
        Size = info.GetValue<ushort>(nameof(Size));
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
    /// Applies the paging information to the specified <paramref name="queryable"/>.
    /// </summary>
    /// <typeparam name="T">The type of element in the queryable.</typeparam>
    /// <param name="queryable">The queryable to which the paging is to be applied.</param>
    /// <returns>A new <see cref="IQueryable{T}"/> with the paging information applied.</returns>
    public virtual IQueryable<T> Apply<T>(IQueryable<T> queryable)
    {
        if (IsNone)
        {
            return queryable;
        }

        return queryable.Skip(Skip).Take(Size);
    }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="Paging"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Page), Page);
        info.AddValue(nameof(Size), Size);
    }

    /// <summary>
    /// Returns a new <see cref="Paging"/> instance representing the next page in the sequence or query.
    /// </summary>
    /// <returns>
    /// A new <see cref="Paging"/> instance representing the next page in the sequence or query.
    /// </returns>
    public virtual Paging Next()
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
    public virtual Paging Previous()
    {
        if (Page == FirstPage)
        {
            return this;
        }

        return new Paging(page: (ushort)(Page - 1), size: Size);
    }
}