namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenPropertiesAreCalled
{
    [Fact]
    public void GivenPascalCasingThenFlagsAreTrue()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Pascal };

        // Act & Assert
        subject.IsCamel.ShouldBeTrue();
        subject.IsPascal.ShouldBeTrue();
    }

    [Fact]
    public void GivenCamelCasingThenFlagsAreFalse()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Camel };

        // Act & Assert
        subject.IsCamel.ShouldBeFalse();
        subject.IsPascal.ShouldBeFalse();
    }
}