namespace Mu.Modelling.ModelTests.OptionsTests;

using MooVC.Syntax.CSharp.Concepts;
using SyntaxOptions = MooVC.Syntax.CSharp.Concepts.Options;
using ModelOptions = Mu.Modelling.Model.Options;

public sealed class WhenImplicitOperatorToSyntaxOptionsIsCalled
{
    [Fact]
    public void GivenOptionsThenSyntaxOptionsAreReturned()
    {
        // Arrange
        SyntaxOptions expected = SyntaxOptions.Default.WithNamespace("Mu.Sample");
        ModelOptions subject = new(ModelOptions.GithubOptions.Default, expected);

        // Act
        SyntaxOptions result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}