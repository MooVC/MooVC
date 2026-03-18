namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenWithFilesIsCalled
{
    [Test]
    public async Task GivenFilesThenReturnsUpdatedInstance()
    {
        // Arrange
        File existing = SolutionTestsData.CreateFile();

        var additional = new File("src/other.cs");

        Solution original = SolutionTestsData.Create(file: existing);

        // Act
        Solution result = original.WithFiles(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Files).IsEqualTo(original.Files.Concat([additional]));
        await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}