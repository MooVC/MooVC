namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "Outcome";

    [Test]
    public async Task GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        var name = new Name(NewName);

        // Act
        Declaration result = original.Named(name);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(name);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(original.Name).IsEqualTo(new Name(DeclarationTestsData.DefaultName));
    }
}