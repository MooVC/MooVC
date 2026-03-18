namespace MooVC.Syntax.CSharp.ResultTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Modifier).IsEqualTo(Result.Kind.Ref);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(original.Modifier).IsEqualTo(Result.Kind.None);
    }
}