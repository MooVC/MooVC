namespace MooVC.Syntax.CSharp.Constructs.KeywordsTests;

public sealed class WhenIsReservedIsCalled
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenNullEmptyOrWhitespaceThenReturnsFalse(string? value)
    {
        // Arrange & Act
        bool result = Keywords.IsReserved(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenAReservedKeywordThenReturnsTrue()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);

        // Act
        bool result = Keywords.IsReserved(keyword);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenAtPrefixedReservedKeywordThenReturnsFalse()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);

        // Act
        bool result = Keywords.IsReserved($"@{keyword}");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenPascalCaseReservedKeywordThenReturnsFalse()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);

        string keyword = Keywords.Reserved
            .ElementAt(element)
            .ToPascalCase();

        // Act
        bool result = Keywords.IsReserved(keyword);

        // Assert
        result.ShouldBeFalse();
    }

    [Theory]
    [InlineData(" class")]
    [InlineData("class ")]
    [InlineData("\tclass")]
    [InlineData("class\t")]
    [InlineData("\nclass")]
    [InlineData("class\n")]
    public void GivenLeadingOrTrailingWhitespaceThenReturnsFalse(string value)
    {
        // Arrange & Act
        bool result = Keywords.IsReserved(value);

        // Assert
        result.ShouldBeFalse();
    }
}