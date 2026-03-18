namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenInModeThenFlagsReflectValue()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.In;

        // Act
        bool isIn = subject.IsIn;
        bool isOut = subject.IsOut;
        bool isNone = subject.IsNone;
        bool isRef = subject.IsRef;

        // Assert
        _ = await Assert.That(isIn).IsTrue();
        _ = await Assert.That(isOut).IsFalse();
        _ = await Assert.That(isNone).IsFalse();
        _ = await Assert.That(isRef).IsFalse();
    }

    [Test]
    public async Task GivenNoneModeThenFlagsReflectValue()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.None;

        // Act
        bool isIn = subject.IsIn;
        bool isOut = subject.IsOut;
        bool isNone = subject.IsNone;
        bool isRef = subject.IsRef;

        // Assert
        _ = await Assert.That(isIn).IsFalse();
        _ = await Assert.That(isOut).IsFalse();
        _ = await Assert.That(isNone).IsTrue();
        _ = await Assert.That(isRef).IsFalse();
    }
}