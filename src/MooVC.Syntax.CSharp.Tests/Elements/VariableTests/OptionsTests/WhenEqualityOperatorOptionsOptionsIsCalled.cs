namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Variable.Options? left = default;
        Variable.Options? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Variable.Options? left = default;
        var right = new Variable.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Variable.Options();
        var right = new Variable.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Variable.Options();
        var right = new Variable.Options { UseUnderscore = true };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}