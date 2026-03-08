namespace Muify.Domain.RaisesAttributeGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    public const string Content = """
        namespace Muify.Domain;

        [global::System.AttributeUsage(global::System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        internal sealed class RaisesAttribute : global::System.Attribute
        {
            public string Name { get; set; }
        }
        """;

    public static readonly Generated Identity = new(
        Content,
        typeof(RaisesAttributeGenerator),
        RaisesAttributeGenerator.Hint);

    [Theory]
    [Frameworks]
    public async Task GivenAnAssemblyThenTheAttributeIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<RaisesAttributeGenerator>(assemblies, language);

        Identity.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}