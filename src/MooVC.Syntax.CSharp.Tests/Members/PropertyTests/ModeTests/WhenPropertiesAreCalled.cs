namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments(0, false, false, true)]
    [Arguments(1, false, true, false)]
    [Arguments(2, true, false, false)]
    public async Task GivenModeThenFlagsMatch(int value, bool expectedInit, bool expectedReadOnly, bool expectedSet)
    {
        // Arrange
        Property.Mode subject = value;

        // Act & Assert
        await Assert.That(subject.IsInit).IsEqualTo(expectedInit);
        await Assert.That(subject.IsReadOnly).IsEqualTo(expectedReadOnly);
        await Assert.That(subject.IsSet).IsEqualTo(expectedSet);
    }

    [Test]
    [Arguments(0, "set")]
    [Arguments(1, "")]
    [Arguments(2, "init")]
    public async Task GivenModeThenToStringMatches(int value, string expected)
    {
        // Arrange
        Property.Mode subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}