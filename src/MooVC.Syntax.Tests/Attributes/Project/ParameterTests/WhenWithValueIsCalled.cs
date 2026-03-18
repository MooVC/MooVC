namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string UpdatedValue = "UpdatedValue";

    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create();
        var updated = Snippet.From(UpdatedValue);

        // Act
        Parameter result = original.WithValue(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Value).IsEqualTo(updated);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}