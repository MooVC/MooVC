namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create();

        // Act
        Func<string> action = () => parameter.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenOptionsThenReturnsParameterStringUsingNaming()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(name: "Value", type: typeof(string));

        var options = new Parameter.Options
        {
            Naming = Variable.Options.Camel,
        };

        // Act
        string result = parameter.ToSnippet(options);

        // Assert
        result.ShouldBe("string value");
    }
}