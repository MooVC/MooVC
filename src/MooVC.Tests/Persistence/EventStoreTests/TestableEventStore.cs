namespace MooVC.Persistence.EventStoreTests
{
    using System;
    using System.Collections.Generic;

    public sealed class TestableEventStore
        : EventStore<object, int>
    {
        private readonly Func<object, int>? insert;
        private readonly Func<int, object?>? readByIndex;
        private readonly Func<int, ushort, IEnumerable<object>>? readFromIndex;

        public TestableEventStore(
            Func<object, int>? insert = default,
            Func<int, object?>? readByIndex = default,
            Func<int, ushort, IEnumerable<object>>? readFromIndex = default)
        {
            this.insert = insert;
            this.readByIndex = readByIndex;
            this.readFromIndex = readFromIndex;
        }

        public override int Insert(object @event)
        {
            if (insert is { })
            {
                return insert(@event);
            }

            throw new NotImplementedException();
        }

        public override object? Read(int index)
        {
            if (readByIndex is { })
            {
                return readByIndex(index);
            }

            throw new NotImplementedException();
        }

        public override IEnumerable<object> Read(int lastIndex, ushort numberToRead = 10)
        {
            if (readFromIndex is { })
            {
                return readFromIndex(lastIndex, numberToRead);
            }

            throw new NotImplementedException();
        }
    }
}