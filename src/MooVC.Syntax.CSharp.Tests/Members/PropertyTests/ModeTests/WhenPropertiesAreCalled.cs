namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments(0, false, false, true)]
    [Arguments(1, false, true, false)]
    [Arguments(2, true, false, false)]
    public void GivenModeThenFlagsMatch(int value, bool expectedInit, bool expectedReadOnly, bool expectedSet)
    {
        // Arrange
        Property.Mode subject = value;

        // Act & Assert
        subject.IsInit.ShouldBe(expectedInit);
        subject.IsReadOnly.ShouldBe(expectedReadOnly);
        subject.IsSet.ShouldBe(expectedSet);
    }

    [Test]
    [Arguments(0, "set")]
    [Arguments(1, "")]
    [Arguments(2, "init")]
    public void GivenModeThenToStringMatches(int value, string expected)
    {
        // Arrange
        Property.Mode subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}