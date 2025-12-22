namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

public sealed class WhenIsPartialIsCalled
{
    [Fact]
    public void GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(isPartial: false);

        // Act
        Class result = original.IsPartial(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsPartial.ShouldBeTrue();
        original.IsPartial.ShouldBeFalse();
    }
}