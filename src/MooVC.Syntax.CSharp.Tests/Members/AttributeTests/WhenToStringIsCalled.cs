namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string ArgumentName = "Value";
    private const string ArgumentValue = "42";
    private const string AttributeName = AttributeTestsData.DefaultName;

    [Test]
    public void GivenUnspecifiedAttributeThenReturnsEmpty()
    {
        // Arrange
        var attribute = new Attribute();

        // Act
        string result = attribute.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenNameThenReturnsAttributeString()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create();

        // Act
        string result = attribute.ToString();

        // Assert
        result.ShouldBe($"[{AttributeName}]");
    }

    [Test]
    public void GivenTargetThenReturnsAttributeStringWithTarget()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create(target: Attribute.Specifier.Method);

        // Act
        string result = attribute.ToString();

        // Assert
        result.ShouldBe($"[{Attribute.Specifier.Method}:{AttributeName}]");
    }

    [Test]
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