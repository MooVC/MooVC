namespace MooVC.Syntax.CSharp.DeclarationTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Name).IsEqualTo(name);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        _ = await Assert.That(original.Name).IsEqualTo(new Name(DeclarationTestsData.DefaultName));
    }
}