namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenToStringIsCalled
{
    private const string Alias = "Alias";

    [Test]
    public async Task GivenAliasThenReturnsAliasDirectiveRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new(Alias),
            Qualifier = new(["MooVC", "Syntax"]),
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("using Alias = MooVC.Syntax;");
    }

    [Test]
    public async Task GivenStaticUsingThenReturnsStaticDirectiveRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            IsStatic = true,
            Qualifier = new(["System", "Console"]),
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("using static System.Console;");
    }

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
}