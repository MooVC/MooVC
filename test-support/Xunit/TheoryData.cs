namespace Xunit;

using System.Collections;

public class TheoryData<T1> : IEnumerable<object?[]>
{
    private readonly List<object?[]> values = [];

    public void Add(T1 item1)
    {
        this.values.Add([item1]);
    }

    public IEnumerator<object?[]> GetEnumerator()
    {
        return this.values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class TheoryData<T1, T2> : IEnumerable<object?[]>
{
    private readonly List<object?[]> values = [];

    public void Add(T1 item1, T2 item2)
    {
        this.values.Add([item1, item2]);
    }

    public IEnumerator<object?[]> GetEnumerator()
    {
        return this.values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
