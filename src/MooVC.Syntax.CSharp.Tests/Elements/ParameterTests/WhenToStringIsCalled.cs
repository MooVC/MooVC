namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Formatting;

public sealed class WhenToStringIsCalled
{
    private const string AttributeName = "Obsolete";
    private const string Default = "42";

    [Test]
    public async Task GivenUndefinedParameterThenReturnsEmpty()
    {
        // Arrange
        Parameter parameter = Parameter.Undefined;

        // Act
        string result = parameter.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsParameterString()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            modifier: Parameter.Mode.Ref,
            @default: Snippet.From(Default));

        // Act
        string result = parameter.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"{Parameter.Mode.Ref} {ParameterTestsData.DefaultType} {ParameterTestsData.DefaultName.ToCamelCase()} = {Default}");
    }

    [Test]
    public async Task GivenAttributesThenReturnsParameterStringWithAttributes()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            attributes: new Attribute
            {
                Name = new Symbol { Name = AttributeName },
            },
            modifier: Parameter.Mode.Out);

        // Act
        string result = parameter.ToString();

        // Assert
        _ = await Assert.That(result).Contains(AttributeName);
        _ = await Assert.That(result).Contains(Parameter.Mode.Out);
        _ = await Assert.That(result).Contains(ParameterTestsData.DefaultName.ToCamelCase());
    }
}