namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenIsStaticIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedStaticState()
    {
        // Arrange
        var original = new Directive
        {
            Qualifier = new(["MooVC", "Syntax"]),
        };

        // Act
        Directive result = original.IsStatic(true);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.IsStatic).IsTrue();
        _ = await Assert.That(result.Alias).IsEqualTo(original.Alias);
        _ = await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        _ = await Assert.That(original.IsStatic).IsFalse();
    }
}