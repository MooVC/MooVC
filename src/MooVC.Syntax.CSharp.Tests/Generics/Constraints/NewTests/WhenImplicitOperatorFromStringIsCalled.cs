namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public void GivenNewConstraintThenCreatesNew()
    {
        // Arrange
        const string Value = "new()";

        // Act
        New result = Value;

        // Assert
        result.ToString().ShouldBe(Value);
    }

    [Test]
    public void GivenEmptyValueThenCreatesNew()
    {
        // Arrange
        const string Value = "";

        // Act
        New result = Value;

        // Assert
        result.ToString().ShouldBe(Value);
    }
}