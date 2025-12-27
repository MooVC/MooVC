namespace MooVC.Syntax.CSharp.Members.ExtensibilityTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Fact]
    public void GivenStaticAbstractThenCombinedExtensibilityReturned()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Abstract;

        // Act
        Extensibility result = left + right;

        // Assert
        result.ToString().ShouldBe("static abstract");
    }

    [Fact]
    public void GivenSealedOverrideThenCombinedExtensibilityReturned()
    {
        // Arrange
        Extensibility left = Extensibility.Sealed;
        Extensibility right = Extensibility.Override;

        // Act
        Extensibility result = left + right;

        // Assert
        result.ToString().ShouldBe("sealed override");
    }

    [Fact]
    public void GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Override;

        // Act
        Func<Extensibility> result = () => left + right;

        // Assert
        _ = result.ShouldThrow<InvalidOperationException>();
    }
}
