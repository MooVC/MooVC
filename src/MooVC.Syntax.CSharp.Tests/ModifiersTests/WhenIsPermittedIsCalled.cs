namespace MooVC.Syntax.CSharp.ModifiersTests;

public sealed class WhenIsPermittedIsCalled
{
    [Test]
    public async Task GivenPermittedValuesThenReturnsTrue()
    {
        // Arrange
        Modifiers subject = Modifiers.Static;

        // Act
        bool result = subject.IsPermitted(Modifiers.Abstract, Modifiers.Static);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenUnpermittedValuesThenReturnsFalse()
    {
        // Arrange
        Modifiers subject = Modifiers.Virtual;

        // Act
        bool result = subject.IsPermitted(Modifiers.Override, Modifiers.Sealed);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}