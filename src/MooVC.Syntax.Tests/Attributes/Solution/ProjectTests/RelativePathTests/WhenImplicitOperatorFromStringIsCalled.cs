namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "src/Project.csproj";

        // Act
        Project.RelativePath subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}