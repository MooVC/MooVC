namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "DebuggerStepThrough";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create();

        // Act
        Attribute result = original.Named(new Symbol { Name = new Variable(NewName) });

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(new Symbol { Name = new Variable(NewName) });
        result.Arguments.ShouldBe(original.Arguments);
        result.Target.ShouldBe(original.Target);
        original.Name.ShouldBe(new Symbol { Name = new Variable(AttributeTestsData.DefaultName) });
    }
}