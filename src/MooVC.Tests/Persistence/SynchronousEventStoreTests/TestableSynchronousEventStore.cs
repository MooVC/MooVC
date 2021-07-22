namespace MooVC.Persistence.SynchronousEventStoreTests
{
    using System;
    using System.Collections.Generic;

    public sealed class TestableSynchronousEventStore
        : SynchronousEventStore<object, int>
    {
        private readonly Func<object, int>? insert;
        private readonly Func<int, object?>? getByIndex;
        private readonly Func<int, ushort, IEnumerable<object>>? readFromIndex;

        public TestableSynchronousEventStore(
            Func<object, int>? insert = default,
            Func<int, object?>? getByIndex = default,
            Func<int, ushort, IEnumerable<object>>? readFromIndex = default)
        {
            this.insert = insert;
            this.getByIndex = getByIndex;
            this.readFromIndex = readFromIndex;
        }

        protected override int PerformInsert(object @event)
        {
            if (insert is { })
            {
                return insert(@event);
            }

            throw new NotImplementedException();
        }

        protected override object? PerformGet(int index)
        {
            if (getByIndex is { })
            {
                return getByIndex(index);
            }

            throw new NotImplementedException();
        }

        protected override IEnumerable<object> PerformRead(int lastIndex, ushort numberToRead = 10)
        {
            if (readFromIndex is { })
            {
                return readFromIndex(lastIndex, numberToRead);
            }

            throw new NotImplementedException();
        }
    }
}