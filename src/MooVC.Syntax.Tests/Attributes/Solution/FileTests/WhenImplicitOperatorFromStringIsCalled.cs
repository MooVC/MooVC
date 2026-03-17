namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
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