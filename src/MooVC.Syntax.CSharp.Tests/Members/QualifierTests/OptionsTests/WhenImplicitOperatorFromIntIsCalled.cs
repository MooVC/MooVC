namespace MooVC.Syntax.CSharp.Members.QualifierTests.OptionsTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int FileValue = 0;
    private const int BlockValue = 1;

    [Fact]
    public void GivenValueThenEqualsInt()
    {
        // Arrange
        int value = BlockValue;

        // Act
        Qualifier.Options subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        int value = FileValue;

        // Act
        Qualifier.Options subject = value;
        int result = subject;

        // Assert
        result.ShouldBe(value);
    }
}
