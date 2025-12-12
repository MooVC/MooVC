namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenInequalityOperatorMethodMethodIsCalled
{
    [Fact]
    public void GivenEquivalentMethodsThenReturnsFalse()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentMethodsThenReturnsTrue()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeTrue();
    }
}