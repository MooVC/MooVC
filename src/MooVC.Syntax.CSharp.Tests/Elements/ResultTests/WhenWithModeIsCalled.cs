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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Mode).IsEqualTo(Result.Modality.Synchronous);
        _ = await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(original.Mode).IsEqualTo(Result.Modality.Asynchronous);
    }
}