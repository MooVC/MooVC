namespace MooVC.Syntax.CSharp.NaturesTests;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    [Arguments(nameof(Natures.Class))]
    [Arguments(nameof(Natures.Struct))]
    [Arguments(nameof(Natures.Unmanaged))]
    [Arguments(nameof(Natures.NotNull))]
    public async Task GivenSpecificNaturesThenReturnsFalse(string field)
    {
        // Arrange
        Natures subject = typeof(Natures)
            .GetField(field)!
            .GetValue(null) as Natures ?? Natures.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenUnspecifiedNaturesThenReturnsTrue()
    {
        // Arrange
        Natures subject = Natures.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}