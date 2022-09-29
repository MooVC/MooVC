namespace MooVC.EnsureTests;

using System;
using Xunit;
using static MooVC.Ensure;

public sealed class WhenInRangeIsCalled
{
    [Theory]
    [InlineData(50, 40, 45)]
    public void GivenAByteWithinRangeThenNoExceptionIsThrown(
        byte end,
        byte start,
        byte value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData((byte)50, (byte)40, (byte)60)]
    [InlineData((byte)(byte.MaxValue - 1), byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        byte? end,
        byte? start,
        byte? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData("Something", (byte)50, (byte)40, (byte)60)]
    [InlineData("something", (byte)(byte.MaxValue - 1), byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteAboveTheEndRangeWhenAnArgumentNameIsProvidedThenArgumentOutOfRangeExceptionIsThrownWithTheArgumentName(
        string argumentName,
        byte? end,
        byte? start,
        byte? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, argumentName: argumentName, end: end, start: start));

        Assert.Equal(argumentName, exception.ParamName);
    }

    [Theory]
    [InlineData(byte.MinValue, (byte)50, (byte)40, (byte)60)]
    [InlineData(byte.MaxValue, (byte)(byte.MaxValue - 1), byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteAboveTheEndRangeWhenADefaultIsProvidedThenDefaultIsReturned(
        byte @default,
        byte? end,
        byte? start,
        byte? value)
    {
        byte actual = InRange(value, @default: @default, end: end, start: start);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData((byte)50, (byte)40, (byte)30)]
    [InlineData(byte.MaxValue, (byte)(byte.MinValue + 1), byte.MinValue)]
    public void GivenANonNullNullablleByteBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        byte? end,
        byte? start,
        byte? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData("Something", (byte)50, (byte)40, (byte)30)]
    [InlineData("something", byte.MaxValue, (byte)(byte.MinValue + 1), byte.MinValue)]
    public void GivenANonNullNullablleByteBelowTheStartRangeWhenAnArgumentNameIsProvidedThenArgumentOutOfRangeExceptionIsThrownWithTheArgumentName(
        string argumentName,
        byte? end,
        byte? start,
        byte? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, argumentName: argumentName, end: end, start: start));

        Assert.Equal(argumentName, exception.ParamName);
    }

    [Theory]
    [InlineData(byte.MinValue, (byte)50, (byte)40, (byte)30)]
    [InlineData(byte.MaxValue, byte.MaxValue, (byte)(byte.MinValue + 1), byte.MinValue)]
    public void GivenANonNullNullablleByteBelowTheStartRangeWhenADefaultIsProvidedThenDefaultIsReturned(
        byte @default,
        byte? end,
        byte? start,
        byte? value)
    {
        byte actual = InRange(value, @default: @default, end: end, start: start);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData((byte)50, (byte)40, (byte)45)]
    [InlineData(byte.MaxValue, byte.MinValue, byte.MinValue)]
    [InlineData(byte.MaxValue, byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteWithinRangeThenNoExceptionIsThrown(
        byte? end,
        byte? start,
        byte? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleByteWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        byte? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void GivenANullNullablleByteWithinRangeWhenAnArgumentNameIsProvidedThenArgumentOutOfRangeExceptionIsThrownWithTheArgumentName()
    {
        const string ArgumentName = "something...";
        byte? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value, argumentName: ArgumentName));

        Assert.Equal(ArgumentName, exception.ParamName);
    }

    [Theory]
    [InlineData(byte.MinValue)]
    [InlineData(127)]
    [InlineData(byte.MaxValue)]
    public void GivenANullNullablleByteWithinRangeWhenADefaultIsProvidedThenDefaultIsReturned(byte @default)
    {
        byte? value = default;

        byte actual = InRange(value, @default: @default);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData(50, 40, 45)]
    public void GivenAByteWithinRangeWithAMessageThenNoExceptionIsThrown(
        byte end,
        byte start,
        byte value)
    {
        const string Message = "Irrelevant";

        _ = InRange(value, end: end, message: Message, start: start);
    }

    [Theory]
    [InlineData((byte)50, (byte)40, (byte)60)]
    [InlineData((byte)(byte.MaxValue - 1), byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteAboveTheEndRangeWithAMessageThenArgumentOutOfRangeExceptionIsThrown(
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Something something dark side...";

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, message: Message, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Theory]
    [InlineData("Something", (byte)50, (byte)40, (byte)60)]
    [InlineData("something", (byte)(byte.MaxValue - 1), byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteAboveTheEndRangeWithAMessageWhenAnArgumentNameIsProvidedThenArgumentOutOfRangeExceptionIsThrownWithTheArgumentName(
        string argumentName,
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Something something dark side...";

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, argumentName: argumentName, end: end, message: Message, start: start));

        Assert.Equal(argumentName, exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Theory]
    [InlineData(byte.MinValue, (byte)50, (byte)40, (byte)60)]
    [InlineData(byte.MaxValue, (byte)(byte.MaxValue - 1), byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteAboveTheEndRangeWithAMessageWhenADefaultIsProvidedThenDefaultIsReturned(
        byte @default,
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Something something dark side...";

        byte actual = InRange(value, @default: @default, end: end, message: Message, start: start);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData((byte)50, (byte)40, (byte)30)]
    [InlineData(byte.MaxValue, (byte)(byte.MinValue + 1), byte.MinValue)]
    public void GivenANonNullNullablleByteBelowTheStartRangeWithAMessageThenArgumentOutOfRangeExceptionIsThrown(
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Something something dark side...";

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, message: Message, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Theory]
    [InlineData("Something", (byte)50, (byte)40, (byte)30)]
    [InlineData("something", byte.MaxValue, (byte)(byte.MinValue + 1), byte.MinValue)]
    public void GivenANonNullNullablleByteBelowTheStartRangeWithAMessageWhenAnArgumentNameIsProvidedThenArgumentOutOfRangeExceptionIsThrownWithTheArgumentName(
        string argumentName,
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Something something dark side...";

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, argumentName: argumentName, end: end, message: Message, start: start));

        Assert.Equal(argumentName, exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Theory]
    [InlineData(byte.MinValue, (byte)50, (byte)40, (byte)30)]
    [InlineData(byte.MaxValue, byte.MaxValue, (byte)(byte.MinValue + 1), byte.MinValue)]
    public void GivenANonNullNullablleByteBelowTheStartRangeWithAMessageWhenADefaultIsProvidedThenDefaultIsReturned(
        byte @default,
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Something something dark side...";

        byte actual = InRange(value, @default: @default, end: end, message: Message, start: start);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData((byte)50, (byte)40, (byte)45)]
    [InlineData(byte.MaxValue, byte.MinValue, byte.MinValue)]
    [InlineData(byte.MaxValue, byte.MinValue, byte.MaxValue)]
    public void GivenANonNullNullablleByteWithinRangeWithAMessageThenNoExceptionIsThrown(
        byte? end,
        byte? start,
        byte? value)
    {
        const string Message = "Irrelevant";

        _ = InRange(value, end: end, message: Message, start: start);
    }

    [Fact]
    public void GivenANullNullablleByteWithinRangeWithAMessageThenAnArgumentNullExceptionIsThrown()
    {
        const string Message = "Something something dark side...";

        byte? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value, message: Message));

        Assert.Equal(nameof(value), exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Fact]
    public void GivenANullNullablleByteWithinRangeWithAMessageWhenAnArgumentNameIsProvidedThenArgumentOutOfRangeExceptionIsThrownWithTheArgumentName()
    {
        const string ArgumentName = "Something else...";
        const string Message = "Something something dark side...";

        byte? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value, argumentName: ArgumentName, message: Message));

        Assert.Equal(ArgumentName, exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Theory]
    [InlineData(byte.MinValue)]
    [InlineData(127)]
    [InlineData(byte.MaxValue)]
    public void GivenANullNullablleByteWithinRangeWithAMessageWhenADefaultIsProvidedThenDefaultIsReturned(byte @default)
    {
        const string Message = "Something something dark side...";

        byte? value = default;

        byte actual = InRange(value, @default: @default, message: Message);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData(50, 40, 45)]
    public void GivenAnSignedByteWithinRangeThenNoExceptionIsThrown(
        sbyte end,
        sbyte start,
        sbyte value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData((sbyte)50, (sbyte)40, (sbyte)60)]
    [InlineData((sbyte)(sbyte.MaxValue - 1), sbyte.MinValue, sbyte.MaxValue)]
    public void GivenANonNullNullablleSignedByteAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        sbyte? end,
        sbyte? start,
        sbyte? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData((sbyte)50, (sbyte)40, (sbyte)30)]
    [InlineData(sbyte.MaxValue, (sbyte)(sbyte.MinValue + 1), sbyte.MinValue)]
    public void GivenANonNullNullablleSignedByteBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        sbyte? end,
        sbyte? start,
        sbyte? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData((sbyte)50, (sbyte)40, (sbyte)45)]
    [InlineData(sbyte.MaxValue, sbyte.MinValue, sbyte.MinValue)]
    [InlineData(sbyte.MaxValue, sbyte.MinValue, sbyte.MaxValue)]
    public void GivenANonNullNullablleSignedByteWithinRangeThenNoExceptionIsThrown(
        sbyte? end,
        sbyte? start,
        sbyte? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleSignedByteWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        sbyte? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50, 40, 45)]
    public void GivenAShortWithinRangeThenNoExceptionIsThrown(
        short end,
        short start,
        short value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData((short)50, (short)40, (short)60)]
    [InlineData((short)(short.MaxValue - 1), short.MinValue, short.MaxValue)]
    public void GivenANonNullNullablleShortAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        short? end,
        short? start,
        short? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData((short)50, (short)40, (short)30)]
    [InlineData(short.MaxValue, (short)(short.MinValue + 1), short.MinValue)]
    public void GivenANonNullNullablleShortBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        short? end,
        short? start,
        short? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData((short)50, (short)40, (short)45)]
    [InlineData(short.MaxValue, short.MinValue, short.MinValue)]
    [InlineData(short.MaxValue, short.MinValue, short.MaxValue)]
    public void GivenANonNullNullablleShortWithinRangeThenNoExceptionIsThrown(
        short? end,
        short? start,
        short? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleShortWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        short? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50, 40, 45)]
    public void GivenAnUnsignedShortWithinRangeThenNoExceptionIsThrown(
        ushort end,
        ushort start,
        ushort value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData((ushort)50, (ushort)40, (ushort)60)]
    [InlineData((ushort)(ushort.MaxValue - 1), ushort.MinValue, ushort.MaxValue)]
    public void GivenANonNullNullablleUnsignedShortAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        ushort? end,
        ushort? start,
        ushort? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData((ushort)50, (ushort)40, (ushort)30)]
    [InlineData(ushort.MaxValue, (ushort)(ushort.MinValue + 1), ushort.MinValue)]
    public void GivenANonNullNullablleUnsignedShortBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        ushort? end,
        ushort? start,
        ushort? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData((ushort)50, (ushort)40, (ushort)45)]
    [InlineData(ushort.MaxValue, ushort.MinValue, ushort.MinValue)]
    [InlineData(ushort.MaxValue, ushort.MinValue, ushort.MaxValue)]
    public void GivenANonNullNullablleUnsignedShortWithinRangeThenNoExceptionIsThrown(
        ushort? end,
        ushort? start,
        ushort? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleUnsignedShortWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        ushort? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50, 40, 45)]
    public void GivenAnIntegerWithinRangeThenNoExceptionIsThrown(
        int end,
        int start,
        int value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData(50, 40, 60)]
    [InlineData(int.MaxValue - 1, int.MinValue, int.MaxValue)]
    public void GivenANonNullNullablleIntegerAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        int? end,
        int? start,
        int? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50, 40, 30)]
    [InlineData(int.MaxValue, int.MinValue + 1, int.MinValue)]
    public void GivenANonNullNullablleIntegerBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        int? end,
        int? start,
        int? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50, 40, 45)]
    [InlineData(int.MaxValue, int.MinValue, int.MinValue)]
    [InlineData(int.MaxValue, int.MinValue, int.MaxValue)]
    public void GivenANonNullNullablleIntegerWithinRangeThenNoExceptionIsThrown(
        int? end,
        int? start,
        int? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleIntegerWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        int? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50u, 40u, 45u)]
    public void GivenAnUnsignedIntegerWithinRangeThenNoExceptionIsThrown(
        uint end,
        uint start,
        uint value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData(50u, 40u, 60u)]
    [InlineData((uint)(uint.MaxValue - 1u), uint.MinValue, uint.MaxValue)]
    public void GivenANonNullNullablleUnsignedIntegerAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        uint? end,
        uint? start,
        uint? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50u, 40u, 30u)]
    [InlineData(uint.MaxValue, uint.MinValue + 1u, uint.MinValue)]
    public void GivenANonNullNullablleUnsignedIntegerBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        uint? end,
        uint? start,
        uint? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50u, 40u, 45u)]
    [InlineData(uint.MaxValue, uint.MinValue, uint.MinValue)]
    [InlineData(uint.MaxValue, uint.MinValue, uint.MaxValue)]
    public void GivenANonNullNullablleUnsignedIntegerWithinRangeThenNoExceptionIsThrown(
        uint? end,
        uint? start,
        uint? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleUnsignedIntegerWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        uint? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50L, 40L, 45L)]
    public void GivenALongWithinRangeThenNoExceptionIsThrown(
       long end,
       long start,
       long value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData(50L, 40L, 60L)]
    [InlineData((long)(long.MaxValue - 1L), long.MinValue, long.MaxValue)]
    public void GivenANonNullNullablleLongAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        long? end,
        long? start,
        long? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50L, 40L, 30L)]
    [InlineData(long.MaxValue, long.MinValue + 1L, long.MinValue)]
    public void GivenANonNullNullablleLongBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        long? end,
        long? start,
        long? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50L, 40L, 45L)]
    [InlineData(long.MaxValue, long.MinValue, long.MinValue)]
    [InlineData(long.MaxValue, long.MinValue, long.MaxValue)]
    public void GivenANonNullNullablleLongWithinRangeThenNoExceptionIsThrown(
        long? end,
        long? start,
        long? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleLongWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        long? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50ul, 40ul, 45ul)]
    public void GivenAnUnsignedLongWithinRangeThenNoExceptionIsThrown(
       ulong end,
       ulong start,
       ulong value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData(50ul, 40ul, 60ul)]
    [InlineData((ulong)(ulong.MaxValue - 1ul), ulong.MinValue, ulong.MaxValue)]
    public void GivenANonNullNullablleUnsignedLongAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        ulong? end,
        ulong? start,
        ulong? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50ul, 40ul, 30ul)]
    [InlineData(ulong.MaxValue, ulong.MinValue + 1ul, ulong.MinValue)]
    public void GivenANonNullNullablleUnsignedLongBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        ulong? end,
        ulong? start,
        ulong? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50ul, 40ul, 45ul)]
    [InlineData(ulong.MaxValue, ulong.MinValue, ulong.MinValue)]
    [InlineData(ulong.MaxValue, ulong.MinValue, ulong.MaxValue)]
    public void GivenANonNullNullablleUnsignedLongWithinRangeThenNoExceptionIsThrown(
        ulong? end,
        ulong? start,
        ulong? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleUnsignedLongWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        ulong? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50f, 40f, 45f)]
    public void GivenAnFloatWithinRangeThenNoExceptionIsThrown(
       float end,
       float start,
       float value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData(50f, 40f, 60f)]
    [InlineData(0f, float.MinValue, float.MaxValue)]
    public void GivenANonNullNullablleFloatAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        float? end,
        float? start,
        float? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50f, 40f, 30f)]
    [InlineData(float.MaxValue, 0f, float.MinValue)]
    public void GivenANonNullNullablleFloatBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        float? end,
        float? start,
        float? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50f, 40f, 45f)]
    [InlineData(float.MaxValue, float.MinValue, float.MinValue)]
    [InlineData(float.MaxValue, float.MinValue, float.MaxValue)]
    public void GivenANonNullNullablleFloatWithinRangeThenNoExceptionIsThrown(
        float? end,
        float? start,
        float? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleFloatWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        float? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50d, 40d, 45d)]
    public void GivenADoubleWithinRangeThenNoExceptionIsThrown(
       double end,
       double start,
       double value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Theory]
    [InlineData(50d, 40d, 60d)]
    [InlineData(0d, double.MinValue, double.MaxValue)]
    public void GivenANonNullNullablleDoubleAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
        double? end,
        double? start,
        double? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50d, 40d, 30d)]
    [InlineData(double.MaxValue, 0d, double.MinValue)]
    public void GivenANonNullNullablleDoubleBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
        double? end,
        double? start,
        double? value)
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50d, 40d, 45d)]
    [InlineData(double.MaxValue, double.MinValue, double.MinValue)]
    [InlineData(double.MaxValue, double.MinValue, double.MaxValue)]
    public void GivenANonNullNullablleDoubleWithinRangeThenNoExceptionIsThrown(
        double? end,
        double? start,
        double? value)
    {
        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleDoubleWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        double? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50L, 40L, 45L)]
    public void GivenATimeSpanWithinRangeThenNoExceptionIsThrown(
       long endSeconds,
       long startSeconds,
       long valueSecond)
    {
        var end = TimeSpan.FromSeconds(endSeconds);
        var start = TimeSpan.FromSeconds(startSeconds);
        var value = TimeSpan.FromSeconds(valueSecond);

        _ = InRange(
            value,
            nameof(value),
            end: end,
            start: start);
    }

    [Theory]
    [InlineData(50L, 40L, 60L)]
    [InlineData(0L, 0L, TimeSpan.TicksPerDay)]
    public void GivenANonNullNullablleTimeSpanAboveTheEndRangeThenArgumentOutOfRangeExceptionIsThrown(
       long? endSeconds,
       long? startSeconds,
       long? valueSecond)
    {
        TimeSpan? end = endSeconds.HasValue
            ? TimeSpan.FromSeconds(endSeconds.Value)
            : default;

        TimeSpan? start = startSeconds.HasValue
            ? TimeSpan.FromSeconds(startSeconds.Value)
            : default;

        TimeSpan? value = valueSecond.HasValue
            ? TimeSpan.FromSeconds(valueSecond.Value)
            : default;

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50L, 40L, 30L)]
    [InlineData(TimeSpan.TicksPerDay, TimeSpan.TicksPerSecond, 0L)]
    public void GivenANonNullNullablleTimeSpanBelowTheStartRangeThenArgumentOutOfRangeExceptionIsThrown(
       long? endSeconds,
       long? startSeconds,
       long? valueSecond)
    {
        TimeSpan? end = endSeconds.HasValue
            ? TimeSpan.FromSeconds(endSeconds.Value)
            : default;

        TimeSpan? start = startSeconds.HasValue
            ? TimeSpan.FromSeconds(startSeconds.Value)
            : default;

        TimeSpan? value = valueSecond.HasValue
            ? TimeSpan.FromSeconds(valueSecond.Value)
            : default;

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => InRange(value, end: end, start: start));

        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(50L, 40L, 45L)]
    [InlineData(TimeSpan.TicksPerDay, 0L, 0L)]
    [InlineData(TimeSpan.TicksPerDay, 0L, TimeSpan.TicksPerDay)]
    public void GivenANonNullNullablleTimeSpanWithinRangeThenNoExceptionIsThrown(
       long? endSeconds,
       long? startSeconds,
       long? valueSecond)
    {
        TimeSpan? end = endSeconds.HasValue
            ? TimeSpan.FromSeconds(endSeconds.Value)
            : default;

        TimeSpan? start = startSeconds.HasValue
            ? TimeSpan.FromSeconds(startSeconds.Value)
            : default;

        TimeSpan? value = valueSecond.HasValue
            ? TimeSpan.FromSeconds(valueSecond.Value)
            : default;

        _ = InRange(value, end: end, start: start);
    }

    [Fact]
    public void GivenANullNullablleTimeSpanWithinRangeThenAnArgumentNullExceptionIsThrown()
    {
        TimeSpan? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => InRange(value));

        Assert.Equal(nameof(value), exception.ParamName);
    }
}