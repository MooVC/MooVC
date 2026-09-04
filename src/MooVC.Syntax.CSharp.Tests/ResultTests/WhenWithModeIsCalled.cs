namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenWithModeIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create(mode: Result.Modes.Asynchronous);

        // Act
        Result result = original.WithMode(Result.Modes.Synchronous);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Mode).IsEqualTo(Result.Modes.Synchronous);
        _ = await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(original.Mode).IsEqualTo(Result.Modes.Asynchronous);
    }
}