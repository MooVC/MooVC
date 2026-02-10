namespace Mu.Modelling.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string ParameterNameValue = "ParameterName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = new Identifier(ParameterNameValue);
        Parameter subject = ModellingTestData.CreateParameter(name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Parameter));
        result.ShouldContain(ParameterNameValue);
    }
}