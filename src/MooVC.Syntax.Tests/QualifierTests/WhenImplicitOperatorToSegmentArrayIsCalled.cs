namespace MooVC.Syntax.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSegmentArrayIsCalled
{
    private static readonly Name _alpha = new("Alpha");
    private static readonly Name _beta = new("Beta");

    [Test]
    public async Task GivenNullQualifierThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? qualifier = default;

        // Act
        Func<Name[]> result = () => qualifier;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenQualifierThenSegmentsAreReturned()
    {
        // Arrange
        ImmutableArray<Name> value = [_alpha, _beta];
        var qualifier = new Qualifier(value);

        // Act
        Name[] result = qualifier;

        // Assert
        _ = await Assert.That(result).IsEquivalentTo([.. value]);
    }
}