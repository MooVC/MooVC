namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenWithTargetIsCalled
{
    [Test]
    public async Task GivenTargetThenReturnsNewInstanceWithUpdatedTarget()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create();

        // Act
        Attribute result = original.WithTarget(Attribute.Specifier.Return);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Target).IsEqualTo(Attribute.Specifier.Return);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
    }
}