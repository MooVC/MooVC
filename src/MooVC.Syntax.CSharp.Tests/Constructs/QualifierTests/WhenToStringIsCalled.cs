namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Qualifier(default);

        // Act
        string? result = subject.ToString();

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenReturnsEmptyString()
    {
        // Arrange
        var subject = new Qualifier(Array.Empty<Segment>());

        // Act
        string? result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenSingleSegmentThenReturnsSegmentValue()
    {
        // Arrange
        var subject = new Qualifier(new[] { new Segment("Alpha") });

        // Act
        string? result = subject.ToString();

        // Assert
        result.ShouldBe("Alpha");
    }

    [Fact]
    public void GivenMultipleSegmentsThenReturnsDottedNotation()
    {
        // Arrange
        var subject = new Qualifier(new[] { new Segment("Alpha"), new Segment("Beta"), new Segment("Gamma") });

        // Act
        string? result = subject.ToString();

        // Assert
        result.ShouldBe("Alpha.Beta.Gamma");
    }

    [Fact]
    public void GivenSegmentsWithReservedPrefixThenUsesSegmentValues()
    {
        // Arrange
        var subject = new Qualifier(new[] { new Segment("@Alpha"), new Segment("Beta_Gamma") });

        // Act
        string? result = subject.ToString();

        // Assert
        result.ShouldBe("@Alpha.Beta_Gamma");
    }

    [Fact]
    public void GivenVeryLongQualifierThenMatchesConcatenatedValue()
    {
        // Arrange
        Segment[] value =
        {
            new Segment("Very"),
            new Segment("Long"),
            new Segment(new string('x', 128)),
        };

        var subject = new Qualifier(value);

        // Act
        string? result = subject.ToString();

        // Assert
        result.ShouldBe($"Very.Long.{new string('x', 128)}");
    }

    [Fact]
    public void GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Qualifier(new[] { new Segment("Alpha"), new Segment("Beta") });
        var right = new Qualifier(new[] { new Segment("Alpha"), new Segment("Gamma") });

        // Act
        string? leftString = left.ToString();
        string? rightString = right.ToString();

        // Assert
        leftString.ShouldNotBe(rightString);
    }

    [Fact]
    public void GivenRepeatedCallsThenResultIsStable()
    {
        // Arrange
        var subject = new Qualifier(new[] { new Segment("Alpha"), new Segment("Beta") });

        // Act
        string? first = subject.ToString();
        string? second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}
