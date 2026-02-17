namespace Mu.Modelling.ModelTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string ModelNameValue = "ModelName";
    private const string CompanyNameValue = "CompanyName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = new Name(ModelNameValue);
        var company = new Name(CompanyNameValue);
        Model subject = ModellingTestData.CreateModel(company: company, name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Model));
        result.ShouldContain(ModelNameValue);
        result.ShouldContain(CompanyNameValue);
    }
}