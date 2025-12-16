namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

public sealed class WhenWithIsPartialIsCalled
{
    [Fact]
    public void GivenIsPartialThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(isPartial: true);

        // Act
        Record result = original.WithIsPartial(false);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsPartial.ShouldBeFalse();
        original.IsPartial.ShouldBeTrue();
    }
}
