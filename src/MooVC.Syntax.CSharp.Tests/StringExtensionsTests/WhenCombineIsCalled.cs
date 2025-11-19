namespace MooVC.Syntax.CSharp.StringExtensionsTests;

public sealed class WhenCombineIsCalled
{
    private const string Separator = ",";
    private static readonly string[] SampleValues = new[] { "first", "second", "third" };

    [Fact]
    public void GivenSeparatorIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? separator = default;

        // Act
        Action action = () => separator!.Combine(SampleValues);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(separator));
    }

    [Fact]
    public void GivenSeparatorIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string separator = string.Empty;

        // Act
        Action action = () => separator.Combine(SampleValues);

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(separator));
    }

    [Fact]
    public void GivenValuesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        string[]? values = default;

        // Act
        Action action = () => separator.Combine(values!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(values));
    }

    [Fact]
    public void GivenNoValuesThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(Array.Empty<string>());

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenSingleValueThenTheValueIsReturned()
    {
        // Arrange
        string separator = Separator;
        string value = SampleValues[0];

        // Act
        string result = separator.Combine(value);

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(SampleValues);

        // Assert
        result.ShouldBe(string.Join(separator, SampleValues));
    }
}
