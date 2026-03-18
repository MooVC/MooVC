namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenIsReadOnlyIsCalled
{
    [Test]
    public async Task GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        Field original = FieldTestsData.Create(isReadOnly: true);

        // Act
        Field result = original.IsReadOnly(false);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.IsReadOnly).IsFalse();
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.IsReadOnly).IsTrue();
    }
}