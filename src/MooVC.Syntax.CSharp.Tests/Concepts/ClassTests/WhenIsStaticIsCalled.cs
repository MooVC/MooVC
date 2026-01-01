namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

public sealed class WhenIsStaticIsCalled
{
    [Fact]
    public void GivenIsStaticThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(isStatic: false);

        // Act
        Class result = original.IsStatic(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsStatic.ShouldBeTrue();
        original.IsStatic.ShouldBeFalse();
    }
}