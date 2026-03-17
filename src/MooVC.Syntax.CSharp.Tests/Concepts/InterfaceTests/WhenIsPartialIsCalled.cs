namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

public sealed class WhenIsPartialIsCalled
{
    [Test]
    public void GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(isPartial: false);

        // Act
        Interface result = original.IsPartial(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsPartial.ShouldBeTrue();
        original.IsPartial.ShouldBeFalse();
    }
}