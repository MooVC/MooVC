namespace Mu.Modelling.MutationalTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string FactNameValue = "FactName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var fact = new Identifier(FactNameValue);
        Mutational subject = ModellingTestData.CreateMutational(fact: fact);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Mutational));
        result.ShouldContain(FactNameValue);
    }
}