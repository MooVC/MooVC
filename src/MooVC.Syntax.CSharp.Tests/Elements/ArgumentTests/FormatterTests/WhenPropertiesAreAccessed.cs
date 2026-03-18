namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenCallFormatterThenFlagsReflectValue()
    {
        // Arrange
        Argument.Formatter subject = Argument.Formatter.Call;

        // Act
        bool isCall = subject.IsCall;
        bool isDeclaration = subject.IsDeclaration;

        // Assert
        await Assert.That(isCall).IsTrue();
        await Assert.That(isDeclaration).IsFalse();
    }

    [Test]
    public async Task GivenDeclarationFormatterThenFlagsReflectValue()
    {
        // Arrange
        Argument.Formatter subject = Argument.Formatter.Declaration;

        // Act
        bool isCall = subject.IsCall;
        bool isDeclaration = subject.IsDeclaration;

        // Assert
        await Assert.That(isCall).IsFalse();
        await Assert.That(isDeclaration).IsTrue();
    }
}