namespace MooVC.Syntax.CSharp.Members.ResultTests;

public sealed class WhenWithModifierIsCalled
{
    [Fact]
    public void GivenModifierThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create(modifier: Result.Kind.None);

        // Act
        Result result = original.WithModifier(Result.Kind.Ref);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Modifier.ShouldBe(Result.Kind.Ref);
        result.Mode.ShouldBe(original.Mode);
        result.Type.ShouldBe(original.Type);
        original.Modifier.ShouldBe(Result.Kind.None);
    }
}