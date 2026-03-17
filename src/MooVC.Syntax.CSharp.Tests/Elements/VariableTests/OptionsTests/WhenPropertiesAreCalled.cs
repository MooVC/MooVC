namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    public void GivenPascalCasingThenFlagsAreTrue()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Pascal };

        // Act & Assert
        subject.IsCamel.ShouldBeTrue();
        subject.IsPascal.ShouldBeTrue();
    }

    [Test]
    public void GivenCamelCasingThenFlagsAreFalse()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Camel };

        // Act & Assert
        subject.IsCamel.ShouldBeFalse();
        subject.IsPascal.ShouldBeFalse();
    }
}