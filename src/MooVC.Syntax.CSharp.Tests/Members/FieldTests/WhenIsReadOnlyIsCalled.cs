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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.IsReadOnly).IsFalse();
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.IsReadOnly).IsTrue();
    }
}