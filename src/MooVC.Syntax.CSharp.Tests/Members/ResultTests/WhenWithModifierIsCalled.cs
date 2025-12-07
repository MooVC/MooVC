namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithModifierIsCalled
{
    [Fact]
    public void GivenModifierThenReturnsNewInstanceWithUpdatedModifier()
    {
        // Arrange
        Result original = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        Result result = original.WithModifier(Result.Kind.Unsafe);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Mode.ShouldBe(original.Mode);
        result.Modifier.ShouldBe(Result.Kind.Unsafe);
        result.Type.ShouldBe(original.Type);
    }
}
