namespace MooVC.Serialization.SerializableExtensionsTests
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class InternalSerializableObject
        : SerializableObject
    {
        public InternalSerializableObject()
        {
        }

        private InternalSerializableObject(SerializationInfo info, StreamingContext context)
        {
            Boolean = info.GetInternalBoolean(nameof(Boolean));
            Byte = info.GetInternalByte(nameof(Byte));
            Char = info.GetInternalChar(nameof(Char));
            DateTime = info.GetInternalDateTime(nameof(DateTime));
            Decimal = info.GetInternalDecimal(nameof(Decimal));
            Double = info.GetInternalDouble(nameof(Double));
            Short = info.GetInternalInt16(nameof(Short));
            Integer = info.GetInternalInt32(nameof(Integer));
            Long = info.GetInternalInt64(nameof(Long));
            SignedByte = info.GetInternalSbyte(nameof(SignedByte));
            Single = info.GetInternalSingle(nameof(Single));
            String = info.GetInternalString(nameof(String));
            UnsignedShort = info.GetInternalUInt16(nameof(UnsignedShort));
            UnsignedInteger = info.GetInternalUInt32(nameof(UnsignedInteger));
            UnsignedLong = info.GetInternalUInt64(nameof(UnsignedLong));
            Value = info.GetInternalValue<Guid>(nameof(Value));
            Enumerable = info.GetInternalEnumerable<int>(nameof(Enumerable));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddInternalValue(nameof(Boolean), Boolean);
            info.AddInternalValue(nameof(Byte), Byte);
            info.AddInternalValue(nameof(Char), Char);
            info.AddInternalValue(nameof(DateTime), DateTime);
            info.AddInternalValue(nameof(Decimal), Decimal);
            info.AddInternalValue(nameof(Double), Double);
            info.AddInternalValue(nameof(Short), Short);
            info.AddInternalValue(nameof(Integer), Integer);
            info.AddInternalValue(nameof(Long), Long);
            info.AddInternalValue(nameof(SignedByte), SignedByte);
            info.AddInternalValue(nameof(Single), Single);
            info.AddInternalValue(nameof(String), String);
            info.AddInternalValue(nameof(UnsignedShort), UnsignedShort);
            info.AddInternalValue(nameof(UnsignedInteger), UnsignedInteger);
            info.AddInternalValue(nameof(UnsignedLong), UnsignedLong);
            info.AddInternalValue(nameof(Value), Value);
            info.AddInternalEnumerable(nameof(Enumerable), Enumerable);
        }
    }
}