namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.RelativePath("src/Project.csproj");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.RelativePath("src/Project.csproj");

        // Act
        bool result = subject.Equals("src/Other.csproj");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenRelativePathWithSameValueThenReturnsTrue()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var subject = new Project.RelativePath(path);
        object other = new Project.RelativePath(path);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}