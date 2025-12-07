namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsNewInstanceWithUpdatedType()
    {
        // Arrange
        Result original = ResultTestsData.Create(type: typeof(int));
        Symbol type = typeof(string);

        // Act
        Result result = original.WithType(type);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Mode.ShouldBe(original.Mode);
        result.Modifier.ShouldBe(original.Modifier);
        result.Type.ShouldBe(type);
    }
}
