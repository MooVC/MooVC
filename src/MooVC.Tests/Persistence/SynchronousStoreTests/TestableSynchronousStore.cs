namespace MooVC.Persistence.SynchronousStoreTests;

using System;
using MooVC.Linq;

public sealed class TestableSynchronousStore
    : SynchronousStore<string, int>
{
    private readonly Func<string, int>? create;
    private readonly Action<string>? deleteByItem;
    private readonly Action<int>? deleteByKey;
    private readonly Func<int, string?>? getByKey;
    private readonly Func<Paging?, PagedResult<string>>? getAll;
    private readonly Action<string>? update;

    public TestableSynchronousStore(
        Func<string, int>? create = default,
        Action<string>? deleteByItem = default,
        Action<int>? deleteByKey = default,
        Func<int, string?>? getByKey = default,
        Func<Paging?, PagedResult<string>>? getAll = default,
        Action<string>? update = default)
    {
        this.create = create;
        this.deleteByItem = deleteByItem;
        this.deleteByKey = deleteByKey;
        this.getByKey = getByKey;
        this.getAll = getAll;
        this.update = update;
    }

    protected override int PerformCreate(string item)
    {
        if (create is { })
        {
            return create(item);
        }

        throw new NotImplementedException();
    }

    protected override void PerformDelete(string item)
    {
        if (deleteByItem is null)
        {
            throw new NotImplementedException();
        }

        deleteByItem(item);
    }

    protected override void PerformDelete(int key)
    {
        if (deleteByKey is null)
        {
            throw new NotImplementedException();
        }

        deleteByKey(key);
    }

    protected override string? PerformGet(int key)
    {
        if (getByKey is { })
        {
            return getByKey(key);
        }

        throw new NotImplementedException();
    }

    protected override PagedResult<string> PerformGet(Paging? paging = default)
    {
        if (getAll is { })
        {
            return getAll(paging);
        }

        throw new NotImplementedException();
    }

    protected override void PerformUpdate(string item)
    {
        if (update is null)
        {
            throw new NotImplementedException();
        }

        update(item);
    }
}