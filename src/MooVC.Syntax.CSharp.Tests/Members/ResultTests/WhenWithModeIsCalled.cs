namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithModeIsCalled
{
    [Fact]
    public void GivenModeThenReturnsNewInstanceWithUpdatedMode()
    {
        // Arrange
        Result original = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        Result result = original.WithMode(Result.Modality.Asynchronous);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Mode.ShouldBe(Result.Modality.Asynchronous);
        result.Modifier.ShouldBe(original.Modifier);
        result.Type.ShouldBe(original.Type);
    }
}
