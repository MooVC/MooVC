namespace MooVC.Syntax.CSharp.Members.ArgumentTests.FormatterTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenCallFormatterThenFlagsReflectValue()
    {
        // Arrange
        Argument.Formatter subject = Argument.Formatter.Call;

        // Act
        bool isCall = subject.IsCall;
        bool isDeclaration = subject.IsDeclaration;

        // Assert
        isCall.ShouldBeTrue();
        isDeclaration.ShouldBeFalse();
    }

    [Fact]
    public void GivenDeclarationFormatterThenFlagsReflectValue()
    {
        // Arrange
        Argument.Formatter subject = Argument.Formatter.Declaration;

        // Act
        bool isCall = subject.IsCall;
        bool isDeclaration = subject.IsDeclaration;

        // Assert
        isCall.ShouldBeFalse();
        isDeclaration.ShouldBeTrue();
    }
}