namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenValueThenReturnsValue()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var subject = new Project.RelativePath(path);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(path);
    }
}