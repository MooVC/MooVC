namespace Mu;

public readonly record struct Range<T>
    where T : IComparable<T>
{
    public Range(T from, T to)
    {
        if (from.CompareTo(to) > 0)
        {
            throw new ArgumentException($"The {nameof(From)} value of `{from}` must be lower than the To value {nameof(To)} `{to}`.", nameof(to));
        }

        From = from;
        To = to;
    }

    public T From { get; }

    public T To { get; }

    public static implicit operator Range<T>((T From, T To) range)
    {
        return new Range<T>(range.From, range.To);
    }
}