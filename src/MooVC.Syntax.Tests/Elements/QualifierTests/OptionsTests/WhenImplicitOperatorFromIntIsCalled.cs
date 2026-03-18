namespace MooVC.Syntax.Elements.QualifierTests.OptionsTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int FileValue = 0;
    private const int BlockValue = 1;

    [Test]
    public async Task GivenValueThenEqualsInt()
    {
        // Arrange
        int value = BlockValue;

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
        int value = FileValue;

        // Act
        Qualifier.Options subject = value;
        int result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}