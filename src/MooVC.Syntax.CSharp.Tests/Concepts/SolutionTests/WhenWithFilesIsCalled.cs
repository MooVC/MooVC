namespace MooVC.Syntax.CSharp.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Attributes.Solution;

public sealed class WhenWithFilesIsCalled
{
    [Fact]
    public void GivenFilesThenReturnsUpdatedInstance()
    {
        // Arrange
        File existing = SolutionTestsData.CreateFile();

        var additional = new File
        {
            Id = Snippet.From("OtherId"),
            Name = Snippet.From("OtherName"),
            Path = Snippet.From("src/other.cs"),
        };

        Solution original = SolutionTestsData.Create(file: existing);

        // Act
        Solution result = original.WithFiles(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Files.ShouldBe(original.Files.Concat([additional]));
        result.Configurations.ShouldBe(original.Configurations);
    }
}