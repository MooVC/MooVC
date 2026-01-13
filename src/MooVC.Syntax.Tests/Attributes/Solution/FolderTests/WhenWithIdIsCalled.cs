namespace MooVC.Syntax.Attributes.Solution.FolderPathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenRootThenMatchesRootInstance()
    {
        // Arrange
        string value = "/";

        // Act
        Folder.Path subject = value;

        // Assert
        subject.IsRoot.ShouldBeTrue();
        (subject == value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "/Folder/";

        // Act
        Folder.Path subject = value;

        // Assert
        subject.IsRoot.ShouldBeFalse();
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}