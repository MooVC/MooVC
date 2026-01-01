namespace MooVC.Syntax.Elements.QualifierTests.OptionsTests;

public sealed class WhenPropertiesAreCalled
{
    [Theory]
    [InlineData(0, false, true, "File")]
    [InlineData(1, true, false, "Block")]
    public void GivenOptionThenFlagsAndStringMatch(int value, bool expectedBlock, bool expectedFile, string expectedText)
    {
        // Arrange
        Qualifier.Options subject = value;

        // Act
        bool isBlock = subject.IsBlock;
        bool isFile = subject.IsFile;
        string text = subject.ToString();

        // Assert
        isBlock.ShouldBe(expectedBlock);
        isFile.ShouldBe(expectedFile);
        text.ShouldBe(expectedText);
    }
}