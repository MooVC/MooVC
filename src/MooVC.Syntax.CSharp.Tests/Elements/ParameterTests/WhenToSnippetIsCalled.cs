namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create();

        // Act
        Func<string> action = () => parameter.ToSnippet(options: default);

        // Assert
        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenOptionsThenReturnsParameterStringUsingNaming()
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
        await Assert.That(result).IsEqualTo("string value");
    }
}