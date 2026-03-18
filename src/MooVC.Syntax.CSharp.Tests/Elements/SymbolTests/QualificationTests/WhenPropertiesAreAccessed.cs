namespace MooVC.Syntax.CSharp.Elements.SymbolTests.QualificationTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenFullQualificationThenFlagsReflectValue()
    {
        // Arrange
        Symbol.Qualification subject = Symbol.Qualification.Full;

        // Act
        bool isFull = subject.IsFull;
        bool isMinimum = subject.IsMinimum;
        bool isGlobal = subject.IsGlobal;

        // Assert
        await Assert.That(isFull).IsTrue();
        await Assert.That(isMinimum).IsFalse();
        await Assert.That(isGlobal).IsFalse();
    }

    [Test]
    public async Task GivenMinimumQualificationThenFlagsReflectValue()
    {
        // Arrange
        Symbol.Qualification subject = Symbol.Qualification.Minimum;

        // Act
        bool isFull = subject.IsFull;
        bool isMinimum = subject.IsMinimum;
        bool isGlobal = subject.IsGlobal;

        // Assert
        await Assert.That(isFull).IsFalse();
        await Assert.That(isMinimum).IsTrue();
        await Assert.That(isGlobal).IsFalse();
    }

    [Test]
    public async Task GivenGlobalQualificationThenFlagsReflectValue()
    {
        // Arrange
        Symbol.Qualification subject = Symbol.Qualification.Global;

        // Act
        bool isFull = subject.IsFull;
        bool isMinimum = subject.IsMinimum;
        bool isGlobal = subject.IsGlobal;

        // Assert
        await Assert.That(isFull).IsFalse();
        await Assert.That(isMinimum).IsFalse();
        await Assert.That(isGlobal).IsTrue();
    }
}