namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenIsStaticIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedStaticState()
    {
        // Arrange
        var original = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        Directive result = original.IsStatic(true);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsStatic).IsTrue();
        await Assert.That(result.Alias).IsEqualTo(original.Alias);
        await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        await Assert.That(original.IsStatic).IsFalse();
    }
}