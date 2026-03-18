namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenInequalityOperatorTypeStringIsCalled
{
    private const string Same = "+";
    private const string Different = "-";

    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Binary.Type? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Binary.Type? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Binary.Type left = Binary.Type.Add;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Binary.Type left = Binary.Type.Add;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Binary.Type left = Binary.Type.Add;
        string right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}