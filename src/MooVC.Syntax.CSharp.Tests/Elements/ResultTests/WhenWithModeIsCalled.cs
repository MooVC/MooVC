namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenWithModeIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create(mode: Result.Modality.Asynchronous);

        // Act
        Result result = original.WithMode(Result.Modality.Synchronous);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Mode).IsEqualTo(Result.Modality.Synchronous);
        await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(original.Mode).IsEqualTo(Result.Modality.Asynchronous);
    }
}