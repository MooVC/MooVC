namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenNonEmptyValueThenCreatesNature()
    {
        // Arrange
        const string Value = "unmanaged";

        // Act
        Nature result = Value;

        // Assert
        result.ToString().ShouldBe(Value);
    }

    [Fact]
    public void GivenEmptyValueThenCreatesNature()
    {
        // Arrange
        const string Value = "";

        // Act
        Nature result = Value;

        // Assert
        result.ToString().ShouldBe(Value);
    }
}