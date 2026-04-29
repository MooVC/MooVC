namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenToSnippetIsCalled
{
    private const string StaticKeyword = "static";

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