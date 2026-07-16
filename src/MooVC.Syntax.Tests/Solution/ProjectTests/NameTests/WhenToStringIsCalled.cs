namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenToStringIsCalled
{
    private const string Value = "ProjectName";

    [Test]
    public async Task GivenNameThenReturnsUnderlyingValue()
    {
        // Arrange
        var subject = new Project.Name(Value);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }
}