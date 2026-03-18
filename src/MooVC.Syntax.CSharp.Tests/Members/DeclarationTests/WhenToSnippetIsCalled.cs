namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }
}