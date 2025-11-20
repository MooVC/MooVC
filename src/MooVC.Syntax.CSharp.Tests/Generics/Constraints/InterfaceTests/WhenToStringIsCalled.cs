namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Generics;
using MemberIdentifier = MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenToStringIsCalled
{
    private const string InterfaceName = "IExample";

    [Fact]
    public void GivenInterfaceDeclarationThenReturnsName()
    {
        // Arrange
        Interface subject = new Members.Declaration
        {
            Name = new MemberIdentifier(InterfaceName),
        };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(InterfaceName);
    }
}