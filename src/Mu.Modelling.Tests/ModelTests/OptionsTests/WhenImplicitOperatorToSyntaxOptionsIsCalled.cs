namespace Mu.Modelling.ModelTests.OptionsTests;

using SyntaxOptions = MooVC.Syntax.CSharp.Concepts.Options;

public sealed class WhenImplicitOperatorToSyntaxOptionsIsCalled
{
    [Fact]
    public void GivenOptionsThenSyntaxOptionsAreReturned()
    {
        // Arrange
        var expected = SyntaxOptions.Default.WithNamespace("Mu.Sample");
        Model.Options subject = new(Model.Options.GithubOptions.Default, expected);

        // Act
        SyntaxOptions result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}