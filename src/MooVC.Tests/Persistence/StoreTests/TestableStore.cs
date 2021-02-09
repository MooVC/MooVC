namespace MooVC.Persistence.StoreTests
{
    using System;
    using System.Collections.Generic;
    using MooVC.Linq;

    public sealed class TestableStore
        : Store<string, int>
    {
        private readonly Func<string, int>? create;
        private readonly Action<string>? deleteByItem;
        private readonly Action<int>? deleteByKey;
        private readonly Func<int, string?>? getByKey;
        private readonly Func<Paging?, IEnumerable<string>>? getAll;
        private readonly Action<string>? update;

        public TestableStore(
            Func<string, int>? create = default,
            Action<string>? deleteByItem = default,
            Action<int>? deleteByKey = default,
            Func<int, string?>? getByKey = default,
            Func<Paging?, IEnumerable<string>>? getAll = default,
            Action<string>? update = default)
        {
            this.create = create;
            this.deleteByItem = deleteByItem;
            this.deleteByKey = deleteByKey;
            this.getByKey = getByKey;
            this.getAll = getAll;
            this.update = update;
        }

        public override int Create(string item)
        {
            if (create is { })
            {
                return create(item);
            }

            throw new NotImplementedException();
        }

        public override void Delete(string item)
        {
            if (deleteByItem is null)
            {
                throw new NotImplementedException();
            }

            deleteByItem(item);
        }

        public override void Delete(int key)
        {
            if (deleteByKey is null)
            {
                throw new NotImplementedException();
            }

            deleteByKey(key);
        }

        public override string? Get(int key)
        {
            if (getByKey is { })
            {
                return getByKey(key);
            }

            throw new NotImplementedException();
        }

        public override IEnumerable<string> Get(Paging? paging = default)
        {
            if (getAll is { })
            {
                return getAll(paging);
            }

            throw new NotImplementedException();
        }

        public override void Update(string item)
        {
            if (update is null)
            {
                throw new NotImplementedException();
            }

            update(item);
        }
    }
}