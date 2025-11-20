namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Generics;
using MemberIdentifier = MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenToStringIsCalled
{
    private const string BaseName = "BaseType";

    [Fact]
    public void GivenUnspecifiedBaseThenReturnsEmpty()
    {
        // Arrange
        Base subject = Base.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenSpecifiedBaseThenReturnsName()
    {
        // Arrange
        Base subject = new Symbol { Name = new MemberIdentifier(BaseName) };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(BaseName);
    }
}
