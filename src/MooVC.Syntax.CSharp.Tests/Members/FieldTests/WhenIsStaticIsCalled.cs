namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenIsStaticIsCalled
{
    [Test]
    public async Task GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        Field original = FieldTestsData.Create(isStatic: false);

        // Act
        Field result = original.IsStatic(true);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        await Assert.That(result.IsStatic).IsTrue();
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.IsStatic).IsFalse();
    }
}