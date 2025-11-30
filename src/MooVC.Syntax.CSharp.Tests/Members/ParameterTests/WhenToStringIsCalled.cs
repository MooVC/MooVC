namespace MooVC.Syntax.CSharp.Members.ParameterTests;

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
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create();

        // Act
        Func<string> action = () => parameter.ToString(options: null!);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
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
        result.ShouldBe(" ".Combine(string.Empty, Parameter.Mode.Ref, ParameterTestsData.DefaultName, " = 42"));
    }

    [Fact]
    public void GivenOptionsThenReturnsParameterStringUsingNaming()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(name: "value");
        var options = new Parameter.Options { Naming = Identifier.Options.Pascal };

        // Act
        string result = parameter.ToString(options);

        // Assert
        result.ShouldBe(" ".Combine(string.Empty, Parameter.Mode.None, new Identifier("value").ToString(options.Naming), string.Empty));
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
