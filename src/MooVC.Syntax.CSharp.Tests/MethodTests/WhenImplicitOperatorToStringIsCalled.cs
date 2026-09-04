namespace MooVC.Syntax.CSharp.MethodTests;

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