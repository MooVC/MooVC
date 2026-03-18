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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Target).IsEqualTo(Attribute.Specifier.Return);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
    }
}