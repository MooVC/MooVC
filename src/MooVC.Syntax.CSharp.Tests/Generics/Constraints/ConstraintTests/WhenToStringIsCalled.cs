namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Generics;
using MemberIdentifier = MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenToStringIsCalled
{
    private const string BaseName = "result";
    private const string InterfaceName = "IExample";

    [Fact]
    public void GivenUnspecifiedConstraintThenReturnsEmpty()
    {
        // Arrange
        Constraint constraint = Constraint.Unspecified;

        // Act
        string result = constraint.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenConstraintWithValuesThenReturnsFormattedString()
    {
        // Arrange
        var constraint = new Constraint
        {
            Nature = Nature.Class,
            Base = new Symbol { Name = new MemberIdentifier(BaseName) },
            Interfaces = [new MemberIdentifier(InterfaceName)],
            New = New.Required,
        };

        // Act
        string result = constraint.ToString();

        // Assert
        result.ShouldBe($"where class, {BaseName}, {InterfaceName}, new()");
    }

    [Fact]
    public void GivenMultipleInterfacesThenReturnsAllInterfacesInOrder()
    {
        // Arrange
        const string AdditionalInterfaceName = "IAnother";

        var constraint = new Constraint
        {
            Nature = Nature.Struct,
            Base = new Symbol { Name = new MemberIdentifier(BaseName) },
            Interfaces =
            [
                new MemberIdentifier(InterfaceName),
                new MemberIdentifier(AdditionalInterfaceName),
            ],
        };

        // Act
        string result = constraint.ToString();

        // Assert
        result.ShouldBe($"where struct, {BaseName}, {InterfaceName}, {AdditionalInterfaceName}, ");
    }
}
