namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "ProjectName";

        // Act
        Project.Name subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }
}