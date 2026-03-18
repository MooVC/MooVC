namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Name).IsEqualTo(new Variable(NewName));
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.Name).IsEqualTo(new Variable(FieldTestsData.DefaultName));
    }
}