namespace MooVC.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MooVC.Collections.Generic;
using MooVC.Serialization;
using static MooVC.Ensure;
using static MooVC.Linq.Resources;

[Serializable]
public sealed class PagedResult<T>
    : ISerializable
{
    private readonly Lazy<ulong> count;

    public PagedResult(Paging request, IEnumerable<T> values)
        : this(request, () => (ulong)values.LongCount(), values)
    {
    }

    public PagedResult(Paging request, int total, IEnumerable<T> values)
        : this(request, () => (ulong)total, values)
    {
    }

    public PagedResult(Paging request, long total, IEnumerable<T> values)
        : this(request, () => (ulong)total, values)
    {
    }

    public PagedResult(Paging request, ulong total, IEnumerable<T> values)
        : this(request, () => total, values)
    {
    }

    private PagedResult(Paging request, Func<ulong> total, IEnumerable<T> values)
    {
        Request = ArgumentNotNull(request, nameof(request), PagedResultRequestRequired);
        Total = total();
        Values = values.Snapshot();

        count = new(CalculateCount);
    }

    private PagedResult(SerializationInfo info, StreamingContext context)
    {
        Request = info.TryGetValue(nameof(Request), defaultValue: Paging.Default);
        Total = info.TryGetValue<ulong>(nameof(Total));
        Values = info.TryGetEnumerable<T>(nameof(Values));

        count = new(CalculateCount);
    }

    public ulong Count => count.Value;

    public bool HasResults => Count > 0;

    public bool IsEmpty => Count == 0;

    public Paging Request { get; }

    public ulong Total { get; }

    public IEnumerable<T> Values { get; }

    public T this[int index] => Values.ElementAt(index);

    public static implicit operator T[](PagedResult<T>? result)
    {
        if (result is null)
        {
            return Array.Empty<T>();
        }

        return result.Values.ToArray();
    }

    public static implicit operator ulong(PagedResult<T>? result)
    {
        if (result is null)
        {
            return 0ul;
        }

        return result.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Values.GetEnumerator();
    }

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