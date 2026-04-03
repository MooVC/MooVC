namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string FileValue = "File";
    private const string BlockValue = "Block";

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = BlockValue;

        // Act
        Qualifier.Options subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = FileValue;

        // Act
        Qualifier.Options subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}