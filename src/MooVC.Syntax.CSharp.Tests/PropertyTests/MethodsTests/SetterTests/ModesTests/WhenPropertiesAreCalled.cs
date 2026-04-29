namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests.ModeTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments("Set", false, false, true)]
    [Arguments("ReadOnly", false, true, false)]
    [Arguments("Init", true, false, false)]
    public async Task GivenModeThenFlagsMatch(string value, bool expectedInit, bool expectedReadOnly, bool expectedSet)
    {
        // Arrange
        Property.Methods.Setter.Modes subject = value;

        // Act & Assert
        _ = await Assert.That(subject.IsInit).IsEqualTo(expectedInit);
        _ = await Assert.That(subject.IsReadOnly).IsEqualTo(expectedReadOnly);
        _ = await Assert.That(subject.IsSet).IsEqualTo(expectedSet);
    }

    [Test]
    [Arguments("Set", "set")]
    [Arguments("ReadOnly", "")]
    [Arguments("Init", "init")]
    public async Task GivenModeThenToStringMatches(string value, string expected)
    {
        // Arrange
        Property.Methods.Setter.Modes subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}