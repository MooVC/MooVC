namespace MooVC.Syntax.CSharp.Members.SymbolTests;

using System.Collections.Immutable;

public sealed class WhenToStringIsCalled
{
    private const string Name = "Result";
    private const string FirstArgumentName = "Inner";
    private const string SecondArgumentName = "Other";

    [Fact]
    public void GivenUnspecifiedSymbolThenEmptyReturned()
    {
        // Arrange
        Symbol subject = Symbol.Unspecified;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenNameThenNameReturned()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = new Identifier(Name),
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(Name);
    }

    [Fact]
    public void GivenArgumentsThenNameAndArgumentListReturned()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = new Identifier(Name),
            Arguments = ImmutableArray.Create(
                new Symbol { Name = new Identifier(FirstArgumentName) },
                new Symbol { Name = new Identifier(SecondArgumentName) }),
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe($"{Name}<{FirstArgumentName}, {SecondArgumentName}>");
    }
}
