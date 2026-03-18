namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenEmptyValueThenReturnsEmptyString()
    {
        // Arrange
        var qualifier = new Qualifier([]);

        // Act
        string result = qualifier.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenSegmentsThenReturnsPeriodSeparatedValue()
    {
        // Arrange
        ImmutableArray<Name> value = ["Alpha", "Beta", "Gamma"];
        var qualifier = new Qualifier(value);

        // Act
        string result = qualifier.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("Alpha.Beta.Gamma");
    }
}