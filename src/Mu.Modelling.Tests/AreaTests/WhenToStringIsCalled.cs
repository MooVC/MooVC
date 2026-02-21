namespace Mu.Modelling.AreaTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string AreaNameValue = "AreaName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = AreaNameValue;
        Area subject = ModellingTestData.CreateArea(name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Area));
        result.ShouldContain(AreaNameValue);
    }
}