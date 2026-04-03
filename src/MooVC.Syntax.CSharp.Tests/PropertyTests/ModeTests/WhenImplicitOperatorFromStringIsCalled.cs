namespace MooVC.Syntax.CSharp.PropertyTests.ModeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string SetValue = "Set";
    private const string ReadOnlyValue = "ReadOnly";

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = ReadOnlyValue;

        // Act
        Property.Mode subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = SetValue;

        // Act
        Property.Mode subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}