namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithNameIsCalled
{
    private const string NewName = "DebuggerStepThrough";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create();

        // Act
        Attribute result = original.WithName(new Symbol { Name = new Variable(NewName) });

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(new Symbol { Name = new Variable(NewName) });
        result.Arguments.ShouldBe(original.Arguments);
        result.Target.ShouldBe(original.Target);
        original.Name.ShouldBe(new Symbol { Name = new Variable(AttributeTestsData.DefaultName) });
    }
}