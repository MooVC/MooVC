namespace MooVC.Syntax.CSharp.FieldTests;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "Other";

    [Test]
    public async Task GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Field original = FieldTestsData.Create();

        // Act
        Field result = original.Named(new Variable(NewName));

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(result.Name).IsEqualTo(new Variable(NewName));
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.Name).IsEqualTo(new Variable(FieldTestsData.DefaultName));
    }
}