namespace Mu.Modelling.AttributeTests;

using MooVC.Syntax.Elements;
using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenToStringIsCalled
{
    private const string AttributeNameValue = "AttributeName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = new Identifier(AttributeNameValue);
        ModellingAttribute subject = ModellingTestData.CreateAttribute(name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Attribute));
        result.ShouldContain(AttributeNameValue);
    }
}