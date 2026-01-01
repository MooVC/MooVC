namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenWithModeIsCalled
{
    [Fact]
    public void GivenModeThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create(mode: Result.Modality.Asynchronous);

        // Act
        Result result = original.WithMode(Result.Modality.Synchronous);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Mode.ShouldBe(Result.Modality.Synchronous);
        result.Modifier.ShouldBe(original.Modifier);
        result.Type.ShouldBe(original.Type);
        original.Mode.ShouldBe(Result.Modality.Asynchronous);
    }
}