namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "Other";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Method original = MethodTestsData.Create();

        // Act
        Method result = original.Named(new Declaration { Name = NewName });

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Name.ShouldBe(new Declaration { Name = NewName });
        result.Parameters.ShouldBe(original.Parameters);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
        original.Name.ShouldBe(new Declaration { Name = MethodTestsData.DefaultName });
    }
}