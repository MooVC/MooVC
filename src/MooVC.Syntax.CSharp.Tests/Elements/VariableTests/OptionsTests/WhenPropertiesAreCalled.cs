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
        _ = await Assert.That(subject.IsCamel).IsTrue();
        _ = await Assert.That(subject.IsPascal).IsTrue();
    }

    [Test]
    public async Task GivenCamelCasingThenFlagsAreFalse()
    {
        // Arrange
        var subject = new Variable.Options { Casing = Identifier.Casing.Camel };

        // Act & Assert
        _ = await Assert.That(subject.IsCamel).IsFalse();
        _ = await Assert.That(subject.IsPascal).IsFalse();
    }
}