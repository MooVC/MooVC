namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyCollection()
    {
        // Arrange
        var subject = new Build();

        // Act
        var result = subject.ToFragments();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenDefinedValuesThenReturnsBuildFragment()
    {
        // Arrange
        Build subject = BuildTestsData.Create();

        // Act
        var result = subject.ToFragments();

        // Assert
        _ = await Assert.That(result).HasSingleItem();
        _ = await Assert.That(result[0].Name.LocalName).IsEqualTo(nameof(Build));
    }
}