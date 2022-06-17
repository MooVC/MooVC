namespace MooVC.Serialization.SerializableExtensionsTests;

using System;
using System.Linq;
using System.Runtime.Serialization;

[Serializable]
public sealed class TrySerializableObject
    : SerializableObject
{
    public TrySerializableObject()
    {
    }

    private TrySerializableObject(SerializationInfo info, StreamingContext context)
    {
        Boolean = info.TryGetValue<bool>(nameof(Boolean));
        Byte = info.TryGetValue<byte>(nameof(Byte));
        Char = info.TryGetValue<char>(nameof(Char));
        DateTime = info.TryGetValue<DateTime>(nameof(DateTime));
        Decimal = info.TryGetValue<decimal>(nameof(Decimal));
        Double = info.TryGetValue<double>(nameof(Double));
        Short = info.TryGetValue<short>(nameof(Short));
        Integer = info.TryGetValue<int>(nameof(Integer));
        Long = info.TryGetValue<long>(nameof(Long));
        SignedByte = info.TryGetValue<sbyte>(nameof(SignedByte));
        Single = info.TryGetValue<float>(nameof(Single));
        String = info.TryGetString(nameof(String));
        UnsignedShort = info.TryGetValue<ushort>(nameof(UnsignedShort));
        UnsignedInteger = info.TryGetValue<uint>(nameof(UnsignedInteger));
        UnsignedLong = info.TryGetValue<ulong>(nameof(UnsignedLong));
        Value = info.TryGetValue<Guid>(nameof(Value));
        Enumerable = info.TryGetEnumerable(nameof(Enumerable), Array.Empty<int>());
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddValue(nameof(Boolean), Boolean);
        _ = info.TryAddValue(nameof(Byte), Byte);
        _ = info.TryAddValue(nameof(Char), Char);
        _ = info.TryAddValue(nameof(DateTime), DateTime);
        _ = info.TryAddValue(nameof(Decimal), Decimal);
        _ = info.TryAddValue(nameof(Double), Double);
        _ = info.TryAddValue(nameof(Short), Short);
        _ = info.TryAddValue(nameof(Integer), Integer);
        _ = info.TryAddValue(nameof(Long), Long);
        _ = info.TryAddValue(nameof(SignedByte), SignedByte);
        _ = info.TryAddValue(nameof(Single), Single);
        _ = info.TryAddString(nameof(String), String);
        _ = info.TryAddValue(nameof(UnsignedShort), UnsignedShort);
        _ = info.TryAddValue(nameof(UnsignedInteger), UnsignedInteger);
        _ = info.TryAddValue(nameof(UnsignedLong), UnsignedLong);
        _ = info.TryAddValue(nameof(Value), Value);
        _ = info.TryAddEnumerable(nameof(Enumerable), Enumerable, predicate: value => value.Any());
    }
}