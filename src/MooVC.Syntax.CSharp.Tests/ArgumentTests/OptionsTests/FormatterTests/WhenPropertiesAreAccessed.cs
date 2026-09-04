namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests.FormattersTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenCallFormattersThenFlagsReflectValue()
    {
        // Arrange
        Argument.Options.Formatters subject = Argument.Options.Formatters.Call;

        // Act
        bool isCall = subject.IsCall;
        bool isDeclaration = subject.IsDeclaration;

        // Assert
        _ = await Assert.That(isCall).IsTrue();
        _ = await Assert.That(isDeclaration).IsFalse();
    }

    [Test]
    public async Task GivenDeclarationFormattersThenFlagsReflectValue()
    {
        // Arrange
        Argument.Options.Formatters subject = Argument.Options.Formatters.Declaration;

        // Act
        bool isCall = subject.IsCall;
        bool isDeclaration = subject.IsDeclaration;

        // Assert
        _ = await Assert.That(isCall).IsFalse();
        _ = await Assert.That(isDeclaration).IsTrue();
    }
}