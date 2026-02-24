namespace Muify.Domain.MuifyAttributeGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    public const string Content = """
        namespace Muify.Domain;

        [global::System.AttributeUsage(global::System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        internal sealed class IdentityAttribute : global::System.Attribute
        {
        }
        """;

    public static readonly Generated Identity = new(
        IdentityAttributeGenerator.Content,
        typeof(IdentityAttributeGenerator),
        IdentityAttributeGenerator.Hint);

    [Theory]
    [Frameworks]
    public async Task GivenAnAssemblyThenTheAttributeIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<IdentityAttributeGenerator>(assemblies, language);

        Identity.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}