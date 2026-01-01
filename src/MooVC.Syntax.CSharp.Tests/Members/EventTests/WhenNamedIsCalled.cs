namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string Name = "Handled";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Event original = EventTestsData.Create();
        Identifier name = Name;

        // Act
        Event result = original.Named(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Handler.ShouldBe(original.Handler);
    }
}