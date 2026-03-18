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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        _ = await Assert.That(result.IsStatic).IsTrue();
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.IsStatic).IsFalse();
    }
}