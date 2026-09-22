namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenToSnippetIsCalled
{
    private const string StaticKeyword = "static";

    [Test]
    public async Task GivenExtensionBlockThenBlockIsRenderedWithinClass()
    {
        // Arrange
        Class subject = Type
            .New<Class>()
            .Named("StringExtensions")
            .IsStatic(true)
            .IsPartial(false)
            .WithExtensions(extension => extension
                .Extends(parameter => parameter
                    .Named("Value")
                    .OfType(typeof(string)))
                .WithMethods(method => method
                    .Named("HasContent")
                    .Returns(Result.Void.OfType(typeof(bool)))
                    .WithBody("return value.Length > 0;")));

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        const string Expected = """
            public static class StringExtensions
            {
                extension(string value)
                {
                    public bool HasContent()
                    {
                        return value.Length > 0;
                    }
                }
            }
            """;

        _ = await Assert.That(result).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Class subject = ClassTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenStaticClassThenSignatureIncludesStaticKeyword()
    {
        // Arrange
        Class subject = ClassTestsData.Create(isStatic: true);

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).Contains($"{StaticKeyword} class");
    }
}