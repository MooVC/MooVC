namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenConstructorIsCalled
{
    private const string Value = "explicit";

    [Fact]
    public void GivenAValueThenTheInstanceIsCreated()
    {
        // Act
        var type = new Conversion.Type(Value);

        // Assert
        type.ShouldNotBeNull();
        type.ToString().ShouldBe(Value);
    }
}
