namespace MooVC.Linq;

using System;
using System.Linq;
using System.Runtime.Serialization;
using MooVC.Serialization;
using static System.Math;

[Serializable]
public class Paging
    : ISerializable
{
    public const ushort DefaultSize = 10;
    public const ushort FirstPage = 1;
    public const ushort MinimumSize = 1;
    private static readonly Lazy<Paging> @default = new(() => new Paging());
    private static readonly Lazy<Paging> none = new(() => new Paging(size: ushort.MaxValue));
    private static readonly Lazy<Paging> one = new(() => new Paging(size: 1));

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

    public static Paging Default => @default.Value;

    public static Paging None => none.Value;

    public static Paging One => one.Value;

    public bool IsDefault => this == Default;

    public bool IsNone => this == None;

    public ushort Page { get; } = FirstPage;

    public ushort Size { get; } = DefaultSize;

    public int Skip => (Page - FirstPage) * Size;

    public static implicit operator Paging(ushort size)
    {
        return (FirstPage, size);
    }

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

    public virtual Paging Next()
    {
        if (Page == ushort.MaxValue)
        {
            return this;
        }

        return new Paging(page: (ushort)(Page + 1), size: Size);
    }

    public virtual Paging Previous()
    {
        if (Page == FirstPage)
        {
            return this;
        }

        return new Paging(page: (ushort)(Page - 1), size: Size);
    }
}