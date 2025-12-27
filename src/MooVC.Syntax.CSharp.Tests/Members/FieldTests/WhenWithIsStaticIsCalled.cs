namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenWithIsStaticIsCalled
{
    [Fact]
    public void GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        Field original = FieldTestsData.Create(isStatic: false);

        // Act
        Field result = original.WithIsStatic(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(original.Default);
        result.IsReadOnly.ShouldBe(original.IsReadOnly);
        result.IsStatic.ShouldBeTrue();
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.IsStatic.ShouldBeFalse();
    }
}
