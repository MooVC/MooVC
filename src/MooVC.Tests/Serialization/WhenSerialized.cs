namespace MooVC.Serialization
{
    using System;
    using Xunit;

    public sealed class WhenSerialized
    {
        [Fact]
        public void GivenAnInternalSerializableObjectWhenPropertiesAreSetThenAllPropertiesMatch()
        {
            var serializable = new InternalSerializableObject
            {
                Boolean = true,
                Byte = 1,
                Char = 'T',
                DateTime = DateTime.UtcNow,
                Decimal = 10.5M,
                Double = 100.1,
                Integer = 20,
                Long = 5,
                Short = -36,
                SignedByte = 9,
                Single = -123.04F,
                String = "Hello",
                UnsignedShort = 3,
                UnsignedInteger = 88651,
                UnsignedLong = 9862846,
                Value = "World",
            };

            InternalSerializableObject serialized = serializable.Clone();

            AssertEquality(serializable, serialized);
        }

        [Fact]
        public void GivenAnInternalSerializableObjectWhenNoPropertiesAreSetThenAllPropertiesMatch()
        {
            var serializable = new InternalSerializableObject();
            InternalSerializableObject serialized = serializable.Clone();

            AssertEquality(serializable, serialized);
        }

        [Fact]
        public void GivenATryInternalSerializableObjectWhenPropertiesAreSetThenAllPropertiesMatch()
        {
            var serializable = new TryInternalSerializableObject
            {
                Boolean = true,
                Byte = 1,
                Char = 'T',
                DateTime = DateTime.UtcNow,
                Decimal = 10.5M,
                Double = 100.1,
                Integer = 20,
                Long = 5,
                Short = -36,
                SignedByte = 9,
                Single = -123.04F,
                String = "Hello",
                UnsignedShort = 3,
                UnsignedInteger = 88651,
                UnsignedLong = 9862846,
                Value = "World",
            };

            TryInternalSerializableObject serialized = serializable.Clone();

            AssertEquality(serializable, serialized);
        }

        [Fact]
        public void GivenATryInternalSerializableObjectWhenNoPropertiesAreSetThenAllPropertiesMatch()
        {
            var serializable = new TryInternalSerializableObject();
            TryInternalSerializableObject serialized = serializable.Clone();

            AssertEquality(serializable, serialized);
        }

        [Fact]
        public void GivenATrySerializableObjectWhenPropertiesAreSetThenAllPropertiesMatch()
        {
            var serializable = new TrySerializableObject
            {
                Boolean = true,
                Byte = 1,
                Char = 'T',
                DateTime = DateTime.UtcNow,
                Decimal = 10.5M,
                Double = 100.1,
                Integer = 20,
                Long = 5,
                Short = -36,
                SignedByte = 9,
                Single = -123.04F,
                String = "Hello",
                UnsignedShort = 3,
                UnsignedInteger = 88651,
                UnsignedLong = 9862846,
                Value = "World",
            };

            TrySerializableObject serialized = serializable.Clone();

            AssertEquality(serializable, serialized);
        }

        [Fact]
        public void GivenATrySerializableObjectWhenNoPropertiesAreSetThenAllPropertiesMatch()
        {
            var serializable = new TrySerializableObject();
            TrySerializableObject serialized = serializable.Clone();

            AssertEquality(serializable, serialized);
        }

        private void AssertEquality(SerializableObject expected, SerializableObject actual)
        {
            Assert.Equal(expected.Boolean, actual.Boolean);
            Assert.Equal(expected.Byte, actual.Byte);
            Assert.Equal(expected.Char, actual.Char);
            Assert.Equal(expected.DateTime, actual.DateTime);
            Assert.Equal(expected.Decimal, actual.Decimal);
            Assert.Equal(expected.Double, actual.Double);
            Assert.Equal(expected.Integer, actual.Integer);
            Assert.Equal(expected.Long, actual.Long);
            Assert.Equal(expected.Short, actual.Short);
            Assert.Equal(expected.SignedByte, actual.SignedByte);
            Assert.Equal(expected.Single, actual.Single);
            Assert.Equal(expected.String, actual.String);
            Assert.Equal(expected.UnsignedShort, actual.UnsignedShort);
            Assert.Equal(expected.UnsignedInteger, actual.UnsignedInteger);
            Assert.Equal(expected.UnsignedLong, actual.UnsignedLong);
            Assert.Equal(expected.Value, actual.Value);
            Assert.Equal(expected.Enumerable, actual.Enumerable);
        }
    }
}