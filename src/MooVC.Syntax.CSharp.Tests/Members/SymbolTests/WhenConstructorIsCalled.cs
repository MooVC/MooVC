namespace MooVC.Syntax.CSharp.Members.SymbolTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    private const string ArgumentName = "Inner";

    [Fact]
    public void GivenDefaultsThenSymbolIsUnspecified()
    {
        // Act
        var subject = new Symbol();

        // Assert
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Arguments.ShouldBeEmpty();
        subject.IsUnspecified.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var argument = new Symbol { Name = new Identifier(ArgumentName) };

        // Act
        var subject = new Symbol
        {
            Name = new Identifier(SymbolTestsData.DefaultName),
            Arguments = ImmutableArray.Create(argument),
        };

        // Assert
        subject.Name.ShouldBe(new Identifier(SymbolTestsData.DefaultName));
        subject.Arguments.ShouldBe(new[] { argument });
        subject.IsUnspecified.ShouldBeFalse();
    }
}
