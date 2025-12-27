namespace MooVC.Syntax.CSharp.Members.ArgumentTests.ModeTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenInModeThenFlagsReflectValue()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.In;

        // Act
        bool isIn = subject.IsIn;
        bool isOut = subject.IsOut;
        bool isNone = subject.IsNone;
        bool isRef = subject.IsRef;

        // Assert
        isIn.ShouldBeTrue();
        isOut.ShouldBeFalse();
        isNone.ShouldBeFalse();
        isRef.ShouldBeFalse();
    }

    [Fact]
    public void GivenNoneModeThenFlagsReflectValue()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.None;

        // Act
        bool isIn = subject.IsIn;
        bool isOut = subject.IsOut;
        bool isNone = subject.IsNone;
        bool isRef = subject.IsRef;

        // Assert
        isIn.ShouldBeFalse();
        isOut.ShouldBeFalse();
        isNone.ShouldBeTrue();
        isRef.ShouldBeFalse();
    }
}