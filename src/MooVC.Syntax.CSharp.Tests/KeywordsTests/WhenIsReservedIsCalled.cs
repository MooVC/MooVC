namespace MooVC.Syntax.CSharp.KeywordsTests;

using System.Text;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.Formatting;

public sealed class WhenIsReservedIsCalled
{
    [Test]
    [Arguments(null)]
    [Arguments("")]
    [Arguments("   ")]
    public async Task GivenNullEmptyOrWhitespaceWhenStringThenReturnsFalse(string? value)
    {
        // Arrange & Act
        bool result = value.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenAReservedKeywordWhenStringThenReturnsTrue()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);

        // Act
        bool result = keyword.IsReserved();

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenAtPrefixedReservedKeywordWhenStringThenReturnsFalse()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);

        // Act
        bool result = $"@{keyword}".IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenPascalCaseReservedKeywordWhenStringThenReturnsFalse()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);

        string keyword = Keywords.Reserved
            .ElementAt(element)
            .ToPascalCase();

        // Act
        bool result = keyword.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    [Arguments(" class")]
    [Arguments("class ")]
    [Arguments("\tclass")]
    [Arguments("class\t")]
    [Arguments("\nclass")]
    [Arguments("class\n")]
    public async Task GivenLeadingOrTrailingWhitespaceWhenStringThenReturnsFalse(string value)
    {
        // Arrange & Act
        bool result = value.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullWhenStringBuilderThenReturnsFalse()
    {
        // Arrange
        StringBuilder? builder = default;

        // Act
        bool result = builder.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    [Arguments("")]
    [Arguments("   ")]
    public async Task GivenEmptyOrWhitespaceWhenStringBuilderThenReturnsFalse(string value)
    {
        // Arrange
        var builder = new StringBuilder(value);

        // Act
        bool result = builder.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenAReservedKeywordWhenStringBuilderThenReturnsTrue()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);
        var builder = new StringBuilder(keyword);

        // Act
        bool result = builder.IsReserved();

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenAtPrefixedReservedKeywordWhenStringBuilderThenReturnsFalse()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);
        string keyword = Keywords.Reserved.ElementAt(element);
        var builder = new StringBuilder($"@{keyword}");

        // Act
        bool result = builder.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenPascalCaseReservedKeywordWhenStringBuilderThenReturnsFalse()
    {
        // Arrange
        int element = Random.Shared.Next(Keywords.Reserved.Count);

        string keyword = Keywords.Reserved
            .ElementAt(element)
            .ToPascalCase();

        var builder = new StringBuilder(keyword);

        // Act
        bool result = builder.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    [Arguments(" class")]
    [Arguments("class ")]
    [Arguments("\tclass")]
    [Arguments("class\t")]
    [Arguments("\nclass")]
    [Arguments("class\n")]
    public async Task GivenLeadingOrTrailingWhitespaceWhenStringBuilderThenReturnsFalse(string value)
    {
        // Arrange
        var builder = new StringBuilder(value);

        // Act
        bool result = builder.IsReserved();

        // Assert
        await Assert.That(result).IsFalse();
    }
}