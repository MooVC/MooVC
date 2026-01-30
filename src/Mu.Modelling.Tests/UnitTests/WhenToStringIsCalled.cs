namespace Mu.Modelling.UnitTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string UnitNameValue = "UnitName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = new Identifier(UnitNameValue);
        Unit subject = ModellingTestData.CreateUnit(name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Unit));
        result.ShouldContain(UnitNameValue);
    }
}