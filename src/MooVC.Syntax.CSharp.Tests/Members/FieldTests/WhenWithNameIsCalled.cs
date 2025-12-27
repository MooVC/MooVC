namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenWithNameIsCalled
{
    private const string NewName = "Other";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Field original = FieldTestsData.Create();

        // Act
        Field result = original.WithName(new Identifier(NewName));

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(original.Default);
        result.IsReadOnly.ShouldBe(original.IsReadOnly);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Name.ShouldBe(new Identifier(NewName));
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.Name.ShouldBe(new Identifier(FieldTestsData.DefaultName));
    }
}