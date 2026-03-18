namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        const string name = "ProjectName";
        var first = new Project.Name(name);
        var second = new Project.Name(name);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Project.Name("ProjectName");
        var second = new Project.Name("OtherProjectName");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}