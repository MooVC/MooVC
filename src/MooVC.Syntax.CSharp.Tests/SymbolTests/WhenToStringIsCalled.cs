namespace MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenToStringIsCalled
{
    private const string Name = "Result";
    private const string FirstArgumentName = "Inner";
    private const string SecondArgumentName = "Other";

    [Test]
    public async Task GivenArgumentsThenNameAndArgumentListReturned()
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
        _ = await Assert.That(representation).IsEqualTo($"{Name}<{FirstArgumentName}, {SecondArgumentName}>");
    }

    [Test]
    public async Task GivenNameThenNameReturned()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = Name,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(Name);
    }

    [Test]
    public async Task GivenQualifierThenQualifierPrefixedToName()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create(qualifier: new Qualifier(["MooVC", "Syntax"]));

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(Name);
    }

    [Test]
    public async Task GivenUnspecifiedSymbolThenEmptyReturned()
    {
        // Arrange
        Symbol subject = Symbol.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }
}