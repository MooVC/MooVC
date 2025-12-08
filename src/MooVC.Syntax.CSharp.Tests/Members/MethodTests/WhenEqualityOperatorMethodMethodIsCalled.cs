namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenEqualityOperatorMethodMethodIsCalled
{
    [Fact]
    public void GivenEquivalentMethodsThenReturnsTrue()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentMethodsThenReturnsFalse()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeFalse();
    }
}
