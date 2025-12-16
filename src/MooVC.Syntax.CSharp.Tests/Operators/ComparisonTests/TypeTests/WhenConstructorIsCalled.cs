namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenConstructorIsCalled
{
    private const string Value = "==";

    [Fact]
    public void GivenAValueThenTheInstanceIsCreated()
    {
        // Act
        var type = new Comparison.Type(Value);

        // Assert
        type.ShouldNotBeNull();
        type.ToString().ShouldBe(Value);
    }
}
