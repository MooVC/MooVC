namespace Mu.Modelling.ResultTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string ResultNameValue = "ResultName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = ResultNameValue;
        Result subject = ModellingTestData.CreateResult(name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Result));
        result.ShouldContain(ResultNameValue);
    }
}