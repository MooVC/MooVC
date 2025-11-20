namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Generics;
using MemberIdentifier = MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Fact]
    public void GivenUnspecifiedBaseThenReturnsTrue()
    {
        // Arrange
        Base subject = Base.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSpecifiedBaseThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = new MemberIdentifier("Base") };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeFalse();
    }
}
