namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithNameIsCalled
{
    private const string NewName = "Outcome";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        var name = new Identifier(NewName);

        // Act
        Declaration result = original.WithName(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        result.Parameters.ShouldBe(original.Parameters);
        original.Name.ShouldBe(new Identifier(DeclarationTestsData.DefaultName));
    }
}