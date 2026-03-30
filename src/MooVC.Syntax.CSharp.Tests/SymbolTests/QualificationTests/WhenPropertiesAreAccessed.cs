namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests;

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
        _ = await Assert.That(isFull).IsTrue();
        _ = await Assert.That(isMinimum).IsFalse();
        _ = await Assert.That(isGlobal).IsFalse();
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
        _ = await Assert.That(isFull).IsFalse();
        _ = await Assert.That(isMinimum).IsFalse();
        _ = await Assert.That(isGlobal).IsTrue();
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
        _ = await Assert.That(isFull).IsFalse();
        _ = await Assert.That(isMinimum).IsTrue();
        _ = await Assert.That(isGlobal).IsFalse();
    }
}