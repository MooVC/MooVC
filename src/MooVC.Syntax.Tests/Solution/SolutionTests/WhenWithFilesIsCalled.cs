namespace MooVC.Syntax.Solution.SolutionTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Files).IsEquivalentTo([.. original.Files, additional]);
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}