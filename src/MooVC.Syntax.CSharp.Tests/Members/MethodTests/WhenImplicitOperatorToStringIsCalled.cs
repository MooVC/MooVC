namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenMethodThenStringRepresentationIsReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        // Act
        string representation = subject;

        // Assert
        representation.ShouldBe(subject.ToString());
    }
}