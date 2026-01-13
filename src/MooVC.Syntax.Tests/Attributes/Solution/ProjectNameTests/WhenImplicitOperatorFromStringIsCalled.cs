namespace MooVC.Syntax.Attributes.Solution.ProjectNameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "ProjectName";

        // Act
        Project.Name subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}