namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "Outcome";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        var name = new Identifier(NewName);

        // Act
        Declaration result = original.Named(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        result.Parameters.ShouldBe(original.Parameters);
        original.Name.ShouldBe(new Identifier(DeclarationTestsData.DefaultName));
    }
}