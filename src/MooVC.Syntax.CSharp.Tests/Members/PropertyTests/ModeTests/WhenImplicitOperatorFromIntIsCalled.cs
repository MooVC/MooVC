namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int SetValue = 0;
    private const int ReadOnlyValue = 1;

    [Fact]
    public void GivenValueThenEqualsInt()
    {
        // Arrange
        int value = ReadOnlyValue;

        // Act
        Property.Mode subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        int value = SetValue;

        // Act
        Property.Mode subject = value;
        int result = subject;

        // Assert
        result.ShouldBe(value);
    }
}
