namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenValueThenReturnsValue()
    {
        // Arrange
        const string name = "ProjectName";
        var subject = new Project.Name(name);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(name);
    }
}