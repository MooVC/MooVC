namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Snippet.Options.Strategies(StrategiesTestsData.Primary);
        object other = new Snippet.Options.Strategies(StrategiesTestsData.Primary);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
