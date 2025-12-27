namespace MooVC.Syntax.CSharp.Members.IdentifierTests.OptionsTests;

public sealed class WhenPropertiesAreCalled
{
    [Fact]
    public void GivenPascalCasingThenFlagsAreTrue()
    {
        // Arrange
        var subject = new Identifier.Options { Casing = Identifier.Casing.Pascal };

        // Act & Assert
        subject.IsCamel.ShouldBeTrue();
        subject.IsPascal.ShouldBeTrue();
    }

    [Fact]
    public void GivenCamelCasingThenFlagsAreFalse()
    {
        // Arrange
        var subject = new Identifier.Options { Casing = Identifier.Casing.Camel };

        // Act & Assert
        subject.IsCamel.ShouldBeFalse();
        subject.IsPascal.ShouldBeFalse();
    }
}
