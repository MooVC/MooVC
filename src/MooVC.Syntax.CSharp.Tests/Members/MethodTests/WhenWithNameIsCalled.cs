namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenWithNameIsCalled
{
    private const string NewName = "Other";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Method original = MethodTestsData.Create();

        // Act
        Method result = original.WithName(new Declaration { Name = new Identifier(NewName) });

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Name.ShouldBe(new Declaration { Name = new Identifier(NewName) });
        result.Parameters.ShouldBe(original.Parameters);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
        original.Name.ShouldBe(new Declaration { Name = new Identifier(MethodTestsData.DefaultName) });
    }
}