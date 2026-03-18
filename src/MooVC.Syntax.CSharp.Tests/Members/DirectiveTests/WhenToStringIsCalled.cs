namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string Alias = "Alias";

    [Test]
    public void GivenUndefinedDirectiveThenReturnsEmptyString()
    {
        // Arrange
        Directive subject = Directive.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenStaticUsingThenReturnsStaticDirectiveRepresentation()
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
        result.ShouldBe("using static System.Console;");
    }

    [Test]
    public void GivenAliasThenReturnsAliasDirectiveRepresentation()
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
        result.ShouldBe("using Alias = MooVC.Syntax;");
    }
}