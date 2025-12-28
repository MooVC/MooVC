namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    private const string AttributeName = "Obsolete";
    private const string Default = "42";

    [Fact]
    public void GivenUndefinedParameterThenReturnsEmpty()
    {
        // Arrange
        Parameter parameter = Parameter.Undefined;

        // Act
        string result = parameter.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsParameterString()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            modifier: Parameter.Mode.Ref,
            @default: Snippet.From(Default));

        // Act
        string result = parameter.ToString();

        // Assert
        result.ShouldBe($"{Parameter.Mode.Ref} {ParameterTestsData.DefaultType} {ParameterTestsData.DefaultName.ToCamelCase()} = {Default}");
    }

    [Fact]
    public void GivenAttributesThenReturnsParameterStringWithAttributes()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            attributes: new Attribute
            {
                Name = new Symbol { Name = new Identifier(AttributeName) },
            },
            modifier: Parameter.Mode.Out);

        // Act
        string result = parameter.ToString();

        // Assert
        result.ShouldContain(AttributeName);
        result.ShouldContain(Parameter.Mode.Out);
        result.ShouldContain(ParameterTestsData.DefaultName);
    }
}