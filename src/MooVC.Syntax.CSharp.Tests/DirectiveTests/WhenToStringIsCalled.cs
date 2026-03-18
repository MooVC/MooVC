namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenToStringIsCalled
{
    private const string Alias = "Alias";

    [Test]
    public async Task GivenUndefinedDirectiveThenReturnsEmptyString()
    {
        // Arrange
        Directive subject = Directive.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenStaticUsingThenReturnsStaticDirectiveRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            IsStatic = true,
            Qualifier = new Qualifier(["System", "Console"]),
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("using static System.Console;");
    }

    [Test]
    public async Task GivenAliasThenReturnsAliasDirectiveRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Name(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("using Alias = MooVC.Syntax;");
    }
}