namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenWithNameIsCalled
{
    private const string NewName = "DebuggerStepThrough";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create();

        // Act
        Attribute result = original.WithName(new Symbol { Name = new Identifier(NewName) });

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(new Symbol { Name = new Identifier(NewName) });
        result.Arguments.ShouldBe(original.Arguments);
        result.Target.ShouldBe(original.Target);
        original.Name.ShouldBe(new Symbol { Name = new Identifier(AttributeTestsData.DefaultName) });
    }
}