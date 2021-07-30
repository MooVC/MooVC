namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using static System.String;

    public abstract class SerializableObject
        : ISerializable
    {
        public bool Boolean { get; init; }

        public byte Byte { get; init; }

        public char Char { get; init; }

        public DateTime DateTime { get; init; }

        public decimal Decimal { get; init; }

        public double Double { get; init; }

        public short Short { get; init; }

        public int Integer { get; init; }

        public long Long { get; init; }

        public sbyte SignedByte { get; init; }

        public float Single { get; init; }

        public string String { get; init; } = Empty;

        public ushort UnsignedShort { get; init; }

        public uint UnsignedInteger { get; init; }

        public ulong UnsignedLong { get; init; }

        public object Value1 { get; init; } = Guid.NewGuid();

        public Guid Value2 { get; init; }

        public IEnumerable<int> Enumerable { get; init; } = Array.Empty<int>();

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}