namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenConstructorIsCalled
{
    private const int Value = 1;

    [Fact]
    public void GivenAValueThenTheInstanceIsCreated()
    {
        // Act
        var intent = new Conversion.Intent(Value);

        // Assert
        intent.ShouldNotBeNull();
        intent.ToString().ShouldBe(Value.ToString());
    }
}
