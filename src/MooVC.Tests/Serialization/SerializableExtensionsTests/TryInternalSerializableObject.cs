namespace MooVC.Serialization.SerializableExtensionsTests;

using System;
using System.Linq;
using System.Runtime.Serialization;

[Serializable]
public sealed class TryInternalSerializableObject
    : SerializableObject
{
    public TryInternalSerializableObject()
    {
    }

    private TryInternalSerializableObject(SerializationInfo info, StreamingContext context)
    {
        Boolean = info.TryGetInternalValue<bool>(nameof(Boolean));
        Byte = info.TryGetInternalValue<byte>(nameof(Byte));
        Char = info.TryGetInternalValue<char>(nameof(Char));
        DateTime = info.TryGetInternalValue<DateTime>(nameof(DateTime));
        Decimal = info.TryGetInternalValue<decimal>(nameof(Decimal));
        Double = info.TryGetInternalValue<double>(nameof(Double));
        Short = info.TryGetInternalValue<short>(nameof(Short));
        Integer = info.TryGetInternalValue<int>(nameof(Integer));
        Long = info.TryGetInternalValue<long>(nameof(Long));
        SignedByte = info.TryGetInternalValue<sbyte>(nameof(SignedByte));
        Single = info.TryGetInternalValue<float>(nameof(Single));
        String = info.TryGetInternalString(nameof(String));
        UnsignedShort = info.TryGetInternalValue<ushort>(nameof(UnsignedShort));
        UnsignedInteger = info.TryGetInternalValue<uint>(nameof(UnsignedInteger));
        UnsignedLong = info.TryGetInternalValue<ulong>(nameof(UnsignedLong));
        Value = info.TryGetInternalValue<Guid>(nameof(Value));
        Enumerable = info.TryGetInternalEnumerable(nameof(Enumerable), Enumerable);
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddInternalValue(nameof(Boolean), Boolean);
        _ = info.TryAddInternalValue(nameof(Byte), Byte);
        _ = info.TryAddInternalValue(nameof(Char), Char);
        _ = info.TryAddInternalValue(nameof(DateTime), DateTime);
        _ = info.TryAddInternalValue(nameof(Decimal), Decimal);
        _ = info.TryAddInternalValue(nameof(Double), Double);
        _ = info.TryAddInternalValue(nameof(Short), Short);
        _ = info.TryAddInternalValue(nameof(Integer), Integer);
        _ = info.TryAddInternalValue(nameof(Long), Long);
        _ = info.TryAddInternalValue(nameof(SignedByte), SignedByte);
        _ = info.TryAddInternalValue(nameof(Single), Single);
        _ = info.TryAddInternalString(nameof(String), String);
        _ = info.TryAddInternalValue(nameof(UnsignedShort), UnsignedShort);
        _ = info.TryAddInternalValue(nameof(UnsignedInteger), UnsignedInteger);
        _ = info.TryAddInternalValue(nameof(UnsignedLong), UnsignedLong);
        _ = info.TryAddInternalValue(nameof(Value), Value);
        _ = info.TryAddInternalEnumerable(nameof(Enumerable), Enumerable, predicate: value => value.Any());
    }
}