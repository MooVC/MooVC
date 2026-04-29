namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments(false, true, "File")]
    [Arguments(true, false, "Block")]
    public async Task GivenOptionThenFlagsAndStringMatch(bool expectedBlock, bool expectedFile, string value)
    {
        // Arrange
        Qualifier.Options subject = value;

        // Act
        bool isBlock = subject.IsBlock;
        bool isFile = subject.IsFile;
        string text = subject.ToString();

        // Assert
        _ = await Assert.That(isBlock).IsEqualTo(expectedBlock);
        _ = await Assert.That(isFile).IsEqualTo(expectedFile);
        _ = await Assert.That(text).IsEqualTo(value);
    }
}