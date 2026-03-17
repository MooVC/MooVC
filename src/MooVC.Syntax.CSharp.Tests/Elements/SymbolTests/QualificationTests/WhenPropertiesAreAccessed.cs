namespace MooVC.Syntax.CSharp.Elements.SymbolTests.QualificationTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public void GivenFullQualificationThenFlagsReflectValue()
    {
        // Arrange
        Symbol.Qualification subject = Symbol.Qualification.Full;

        // Act
        bool isFull = subject.IsFull;
        bool isMinimum = subject.IsMinimum;
        bool isGlobal = subject.IsGlobal;

        // Assert
        isFull.ShouldBeTrue();
        isMinimum.ShouldBeFalse();
        isGlobal.ShouldBeFalse();
    }

    [Test]
    public void GivenMinimumQualificationThenFlagsReflectValue()
    {
        // Arrange
        Symbol.Qualification subject = Symbol.Qualification.Minimum;

        // Act
        bool isFull = subject.IsFull;
        bool isMinimum = subject.IsMinimum;
        bool isGlobal = subject.IsGlobal;

        // Assert
        isFull.ShouldBeFalse();
        isMinimum.ShouldBeTrue();
        isGlobal.ShouldBeFalse();
    }

    [Test]
    public void GivenGlobalQualificationThenFlagsReflectValue()
    {
        // Arrange
        Symbol.Qualification subject = Symbol.Qualification.Global;

        // Act
        bool isFull = subject.IsFull;
        bool isMinimum = subject.IsMinimum;
        bool isGlobal = subject.IsGlobal;

        // Assert
        isFull.ShouldBeFalse();
        isMinimum.ShouldBeFalse();
        isGlobal.ShouldBeTrue();
    }
}