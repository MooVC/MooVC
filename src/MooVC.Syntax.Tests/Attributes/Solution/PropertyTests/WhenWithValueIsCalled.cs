namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = Snippet.From("OtherValue");

        // Act
        Property result = original.WithValue(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Value).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}