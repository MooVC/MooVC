namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string StaticKeyword = "static";

    [Test]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Class subject = ClassTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenStaticClassThenSignatureIncludesStaticKeyword()
    {
        // Arrange
        Class subject = ClassTestsData.Create(isStatic: true);

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        result.ShouldContain($"{StaticKeyword} class");
    }
}