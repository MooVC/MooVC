namespace MooVC.Syntax.CSharp.Generics.Constraints.ImplementationTests;

public sealed class WhenToStringIsCalled
{
    private const string ImplementationName = "IExample";

    [Test]
    public async Task GivenImplementationDeclarationThenReturnsName()
    {
        // Arrange
        Implementation subject = new Declaration
        {
            Name = ImplementationName,
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(ImplementationName);
    }
}