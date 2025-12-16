namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithExtensibilityIsCalled
{
    [Fact]
    public void GivenExtensibilityThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(extensibility: Extensibility.Abstract);

        // Act
        Record result = original.WithExtensibility(Extensibility.Implicit);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Extensibility.ShouldBe(Extensibility.Implicit);
        original.Extensibility.ShouldBe(Extensibility.Abstract);
    }
}
