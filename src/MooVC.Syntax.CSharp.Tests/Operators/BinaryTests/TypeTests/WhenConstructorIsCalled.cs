namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenConstructorIsCalled
{
    private const string Value = "add";

    [Fact]
    public void GivenAValueThenTheInstanceIsCreated()
    {
        // Act
        var type = new Binary.Type(Value);

        // Assert
        type.ShouldNotBeNull();
        type.ToString().ShouldBe(Value);
    }
}
