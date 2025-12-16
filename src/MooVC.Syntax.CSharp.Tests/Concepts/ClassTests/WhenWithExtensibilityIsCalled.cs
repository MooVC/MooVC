namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithExtensibilityIsCalled
{
    [Fact]
    public void GivenExtensibilityThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        Class result = original.WithExtensibility(Extensibility.Abstract);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Extensibility.ShouldBe(Extensibility.Abstract);
        result.Name.ShouldBe(original.Name);
        original.Extensibility.ShouldBe(Extensibility.Sealed);
    }
}
