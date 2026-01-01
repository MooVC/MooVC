namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenConstructorIsCalled
{
    private const string ArgumentName = "Inner";

    [Fact]
    public void GivenDefaultsThenSymbolIsUnspecified()
    {
        // Act
        var subject = new Symbol();

        // Assert
        subject.Name.ShouldBe(Variable.Unnamed);
        subject.Arguments.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var argument = new Symbol { Name = new Variable(ArgumentName) };

        // Act
        var subject = new Symbol
        {
            Name = new Variable(SymbolTestsData.DefaultName),
            Arguments = [argument],
        };

        // Assert
        subject.Name.ShouldBe(new Variable(SymbolTestsData.DefaultName));
        subject.Arguments.ShouldBe(new[] { argument });
        subject.IsUndefined.ShouldBeFalse();
    }
}