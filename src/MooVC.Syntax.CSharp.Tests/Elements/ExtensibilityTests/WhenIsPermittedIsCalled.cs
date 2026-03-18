namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenIsPermittedIsCalled
{
    [Test]
    public async Task GivenPermittedValuesThenReturnsTrue()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        bool result = subject.IsPermitted(Extensibility.Abstract, Extensibility.Static);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenUnpermittedValuesThenReturnsFalse()
    {
        // Arrange
        Extensibility subject = Extensibility.Virtual;

        // Act
        bool result = subject.IsPermitted(Extensibility.Override, Extensibility.Sealed);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}