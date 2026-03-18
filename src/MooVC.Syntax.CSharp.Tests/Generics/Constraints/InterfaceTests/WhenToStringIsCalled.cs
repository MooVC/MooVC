namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    private const string InterfaceName = "IExample";

    [Test]
    public void GivenInterfaceDeclarationThenReturnsName()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = InterfaceName,
        };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(InterfaceName);
    }
}