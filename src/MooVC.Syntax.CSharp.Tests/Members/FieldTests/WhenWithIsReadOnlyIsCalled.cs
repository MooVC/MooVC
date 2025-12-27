namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenWithIsReadOnlyIsCalled
{
    [Fact]
    public void GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        Field original = FieldTestsData.Create(isReadOnly: true);

        // Act
        Field result = original.WithIsReadOnly(false);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(original.Default);
        result.IsReadOnly.ShouldBeFalse();
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.IsReadOnly.ShouldBeTrue();
    }
}
