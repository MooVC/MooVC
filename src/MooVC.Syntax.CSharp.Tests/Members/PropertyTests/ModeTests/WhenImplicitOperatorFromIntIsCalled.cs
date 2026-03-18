namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int SetValue = 0;
    private const int ReadOnlyValue = 1;

    [Test]
    public async Task GivenValueThenEqualsInt()
    {
        // Arrange
        int value = ReadOnlyValue;

        // Act
        Property.Mode subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        int value = SetValue;

        // Act
        Property.Mode subject = value;
        int result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}