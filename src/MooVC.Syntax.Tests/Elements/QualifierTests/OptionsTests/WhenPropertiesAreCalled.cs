namespace MooVC.Syntax.Elements.QualifierTests.OptionsTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments(0, false, true, "File")]
    [Arguments(1, true, false, "Block")]
    public async Task GivenOptionThenFlagsAndStringMatch(int value, bool expectedBlock, bool expectedFile, string expectedText)
    {
        // Arrange
        Qualifier.Options subject = value;

        // Act
        bool isBlock = subject.IsBlock;
        bool isFile = subject.IsFile;
        string text = subject.ToString();

        // Assert
        await Assert.That(isBlock).IsEqualTo(expectedBlock);
        await Assert.That(isFile).IsEqualTo(expectedFile);
        await Assert.That(text).IsEqualTo(expectedText);
    }
}