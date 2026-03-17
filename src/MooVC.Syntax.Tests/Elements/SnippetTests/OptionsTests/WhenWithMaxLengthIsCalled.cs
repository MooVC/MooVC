namespace MooVC.Syntax.Elements.SnippetTests.OptionsTests;

public sealed class WhenWithMaxLengthIsCalled
{
    [Test]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        const byte value = 200;

        // Act
        Snippet.Options result = options.WithMaxLength(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.MaxLength.ShouldBe(value);
        options.MaxLength.ShouldNotBe(value);
    }
}