namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using static System.String;

    [Serializable]
    public abstract class SerializableObject
        : ISerializable
    {
        public bool Boolean { get; set; }

        public byte Byte { get; set; }

        public char Char { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Decimal { get; set; }

        public double Double { get; set; }

        public short Short { get; set; }

        public int Integer { get; set; }

        public long Long { get; set; }

        public sbyte SignedByte { get; set; }

        public float Single { get; set; }

        public string String { get; set; } = Empty;

        public ushort UnsignedShort { get; set; }

        public uint UnsignedInteger { get; set; }

        public ulong UnsignedLong { get; set; }

        public object Value { get; set; }

        public IEnumerable<int> Enumerable { get; set; } = new int[0];

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}