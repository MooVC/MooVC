namespace MooVC.Syntax.CSharp.ArgumentTests.FormatterTests;

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
        _ = await Assert.That(isCall).IsTrue();
        _ = await Assert.That(isDeclaration).IsFalse();
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
        _ = await Assert.That(isCall).IsFalse();
        _ = await Assert.That(isDeclaration).IsTrue();
    }
}