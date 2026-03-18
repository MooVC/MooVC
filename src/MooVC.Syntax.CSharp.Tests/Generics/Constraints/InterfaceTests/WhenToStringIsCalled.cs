namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    private const string InterfaceName = "IExample";

    [Test]
    public async Task GivenInterfaceDeclarationThenReturnsName()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = InterfaceName,
        };

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(InterfaceName);
    }
}