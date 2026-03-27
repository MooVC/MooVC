namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenToStringIsCalled
{
    private const string ArgumentName = "Value";
    private const string ArgumentValue = "42";
    private const string AttributeName = AttributeTestsData.DefaultName;

    [Test]
    public async Task GivenUnspecifiedAttributeThenReturnsEmpty()
    {
        // Arrange
        var attribute = new Attribute();

        // Act
        string result = attribute.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenNameThenReturnsAttributeString()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create();

        // Act
        string result = attribute.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(AttributeName);
    }

    [Test]
    public async Task GivenTargetThenReturnsAttributeStringWithTarget()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create(target: Attribute.Specifier.Method);

        // Act
        string result = attribute.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"{Attribute.Specifier.Method}:{AttributeName}");
    }

    [Test]
    public async Task GivenArgumentsThenReturnsAttributeStringWithArguments()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create(
            arguments: new Argument
            {
                Name = new Identifier(ArgumentName),
                Value = Snippet.From(ArgumentValue),
            });

        // Act
        string result = attribute.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"{AttributeName}({ArgumentName} = {ArgumentValue})");
    }
}