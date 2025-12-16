namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

public sealed class WhenWithIsPartialIsCalled
{
    [Fact]
    public void GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(isPartial: false);

        // Act
        Interface result = original.WithIsPartial(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsPartial.ShouldBeTrue();
        original.IsPartial.ShouldBeFalse();
    }
}
