namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenWithIsPartialIsCalled
{
    [Fact]
    public void GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(isPartial: false);

        // Act
        Struct result = original.WithIsPartial(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsPartial.ShouldBeTrue();
        original.IsPartial.ShouldBeFalse();
    }
}
