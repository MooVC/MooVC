namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenPropertiesAreCalled
{
    [Fact]
    public void GivenPascalCasingThenFlagsAreTrue()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Variable.Casing.Pascal };

        // Act & Assert
        subject.IsCamel.ShouldBeTrue();
        subject.IsPascal.ShouldBeTrue();
    }

    [Fact]
    public void GivenCamelCasingThenFlagsAreFalse()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Variable.Casing.Camel };

        // Act & Assert
        subject.IsCamel.ShouldBeFalse();
        subject.IsPascal.ShouldBeFalse();
    }
}