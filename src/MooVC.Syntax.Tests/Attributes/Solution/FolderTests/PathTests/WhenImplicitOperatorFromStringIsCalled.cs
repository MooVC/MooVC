namespace MooVC.Syntax.Attributes.Solution.FolderTests.PathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenRootThenMatchesRootInstance()
    {
        // Arrange
        string value = "/";

        // Act
        Folder.Path subject = value;

        // Assert
        await Assert.That(subject.IsRoot).IsTrue();
        await Assert.That((subject == value)).IsTrue();
    }

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "/Folder/";

        // Act
        Folder.Path subject = value;

        // Assert
        await Assert.That(subject.IsRoot).IsFalse();
        await Assert.That((subject == value)).IsTrue();
        await Assert.That(subject.Equals(value)).IsTrue();
    }
}