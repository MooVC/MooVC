namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = FileTestsData.DefaultPath;

        // Act
        File subject = value;

        // Asserts
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}