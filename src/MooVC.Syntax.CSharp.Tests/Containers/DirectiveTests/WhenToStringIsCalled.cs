namespace MooVC.Syntax.CSharp.Containers.DirectiveTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    private const string Alias = "Alias";

    [Fact]
    public void GivenUndefinedDirectiveThenReturnsEmptyString()
    {
        // Arrange
        Directive subject = Directive.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
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
        result.ShouldBe("using static System.Console");
    }

    [Fact]
    public void GivenAliasThenReturnsAliasDirectiveRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Identifier(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("using Alias =  MooVC.Syntax");
    }
}