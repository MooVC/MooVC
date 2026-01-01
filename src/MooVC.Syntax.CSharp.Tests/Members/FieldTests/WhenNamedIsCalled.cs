namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "Other";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Field original = FieldTestsData.Create();

        // Act
        Field result = original.Named(new Variable(NewName));

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(original.Default);
        result.IsReadOnly.ShouldBe(original.IsReadOnly);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Name.ShouldBe(new Variable(NewName));
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.Name.ShouldBe(new Variable(FieldTestsData.DefaultName));
    }
}