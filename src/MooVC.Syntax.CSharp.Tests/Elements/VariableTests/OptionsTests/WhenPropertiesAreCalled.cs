namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    public async Task GivenPascalCasingThenFlagsAreTrue()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Pascal };

        // Act & Assert
        await Assert.That(subject.IsCamel).IsTrue();
        await Assert.That(subject.IsPascal).IsTrue();
    }

    [Test]
    public async Task GivenCamelCasingThenFlagsAreFalse()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Camel };

        // Act & Assert
        await Assert.That(subject.IsCamel).IsFalse();
        await Assert.That(subject.IsPascal).IsFalse();
    }
}