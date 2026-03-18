namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenWithModifierIsCalled
{
    [Test]
    public async Task GivenModifierThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create(modifier: Result.Kind.None);

        // Act
        Result result = original.WithModifier(Result.Kind.Ref);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Modifier).IsEqualTo(Result.Kind.Ref);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(original.Modifier).IsEqualTo(Result.Kind.None);
    }
}