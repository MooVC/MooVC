namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenConstructorIsCalled
{
    private const string Value = "!";

    [Fact]
    public void GivenAValueThenTheInstanceIsCreated()
    {
        // Act
        var type = new Unary.Type(Value);

        // Assert
        type.ShouldNotBeNull();
        type.ToString().ShouldBe(Value);
    }
}
