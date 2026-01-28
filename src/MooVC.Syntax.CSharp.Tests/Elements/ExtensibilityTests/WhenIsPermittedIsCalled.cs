namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenIsPermittedIsCalled
{
    [Fact]
    public void GivenPermittedValuesThenReturnsTrue()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        bool result = subject.IsPermitted(Extensibility.Abstract, Extensibility.Static);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenUnpermittedValuesThenReturnsFalse()
    {
        // Arrange
        Extensibility subject = Extensibility.Virtual;

        // Act
        bool result = subject.IsPermitted(Extensibility.Override, Extensibility.Sealed);

        // Assert
        result.ShouldBeFalse();
    }
}