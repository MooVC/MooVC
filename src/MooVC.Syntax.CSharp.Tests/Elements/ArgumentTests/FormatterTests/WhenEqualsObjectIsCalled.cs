namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        object? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter first = Argument.Formatter.Call;
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Declaration;
        object right = Argument.Formatter.Declaration;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Formatter)right).Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        object right = Argument.Formatter.Declaration;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Formatter)right).Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        object right = "{0}: {1}";

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}