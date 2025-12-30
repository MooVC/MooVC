namespace MooVC.Syntax.CSharp.Attributes.Solution.ProjectTests;

using MooVC.Syntax.CSharp;

public sealed class WhenEqualsProjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        // Act
        bool result = subject.Equals(default(Project));

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project other = ProjectTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project other = ProjectTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}