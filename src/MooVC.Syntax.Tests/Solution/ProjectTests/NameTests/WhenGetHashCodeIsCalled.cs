namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Project.Name("ProjectName");
        var second = new Project.Name("OtherProjectName");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        const string name = "ProjectName";
        var first = new Project.Name(name);
        var second = new Project.Name(name);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}