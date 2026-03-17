namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string Name = "Result";
    private const string FirstArgumentName = "Inner";
    private const string SecondArgumentName = "Other";

    [Test]
    public void GivenUnspecifiedSymbolThenEmptyReturned()
    {
        // Arrange
        Symbol subject = Symbol.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenNameThenNameReturned()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = Name,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(Name);
    }

    [Test]
    public void GivenArgumentsThenNameAndArgumentListReturned()
    {
        // Arrange
        var subject = new Symbol
        {
            Arguments =
            [
                new Symbol { Name = FirstArgumentName },
                new Symbol { Name = SecondArgumentName },
            ],
            Name = Name,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe($"{Name}<{FirstArgumentName}, {SecondArgumentName}>");
    }

    [Test]
    public void GivenQualifierThenQualifierPrefixedToName()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create(qualifier: new Qualifier(["MooVC", "Syntax"]));

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(Name);
    }
}