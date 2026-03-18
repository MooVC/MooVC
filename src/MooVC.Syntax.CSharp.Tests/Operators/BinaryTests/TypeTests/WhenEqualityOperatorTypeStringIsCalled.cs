namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenEqualityOperatorTypeStringIsCalled
{
    private const string Same = "+";
    private const string Different = "-";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Binary.Type? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Binary.Type? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Binary.Type left = Binary.Type.Add;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Binary.Type left = Binary.Type.Add;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Binary.Type left = Binary.Type.Add;
        string right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}