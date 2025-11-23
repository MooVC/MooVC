namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenToStringIsCalled
{
    private const string ArgumentName = "Value";
    private const string ArgumentValue = "42";
    private const string AttributeName = AttributeTestsData.DefaultName;

    [Fact]
    public void GivenUnspecifiedAttributeThenReturnsEmpty()
    {
        // Arrange
        var attribute = new Attribute();

        // Act
        string result = attribute.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenNameThenReturnsAttributeString()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create();

        // Act
        string result = attribute.ToString();

        // Assert
        result.ShouldBe($"[{AttributeName}]");
    }

    [Fact]
    public void GivenTargetThenReturnsAttributeStringWithTarget()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create(target: Attribute.Specifier.Method);

        // Act
        string result = attribute.ToString();

        // Assert
        result.ShouldBe($"[{Attribute.Specifier.Method}:{AttributeName}]");
    }

    [Fact]
    public void GivenArgumentsThenReturnsAttributeStringWithArguments()
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
        result.ShouldBe($"[{AttributeName}({ArgumentName} = {ArgumentValue})]");
    }
}
