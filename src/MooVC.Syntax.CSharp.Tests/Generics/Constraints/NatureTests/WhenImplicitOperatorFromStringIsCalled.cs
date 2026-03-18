namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public void GivenNonEmptyValueThenCreatesNature()
    {
        // Arrange
        const string Value = "unmanaged";

        // Act
        Nature result = Value;

        // Assert
        result.ToString().ShouldBe(Value);
    }

    [Test]
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