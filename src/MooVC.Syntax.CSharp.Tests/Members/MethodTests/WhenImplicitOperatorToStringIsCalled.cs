namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenMethodThenStringRepresentationIsReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        // Act
        string representation = subject;

        // Assert
        _ = await Assert.That(representation).IsEqualTo(subject.ToString());
    }
}