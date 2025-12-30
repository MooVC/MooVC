namespace MooVC.Syntax.CSharp.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Attributes.Solution;

public sealed class WhenWithFoldersIsCalled
{
    [Fact]
    public void GivenFoldersThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder existing = SolutionTestsData.CreateFolder();

        var additional = new Folder
        {
            Id = Snippet.From("OtherId"),
            Name = Snippet.From("OtherName"),
        };

        Solution original = SolutionTestsData.Create(folder: existing);

        // Act
        Solution result = original.WithFolders(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Folders.ShouldBe(original.Folders.Concat([additional]));
        result.Configurations.ShouldBe(original.Configurations);
    }
}