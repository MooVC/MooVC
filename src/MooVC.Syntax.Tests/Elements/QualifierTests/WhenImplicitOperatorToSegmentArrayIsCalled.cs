namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSegmentArrayIsCalled
{
    private static readonly Name alpha = new("Alpha");
    private static readonly Name beta = new("Beta");

    [Test]
    public async Task GivenNullQualifierThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? qualifier = default;

        // Act
        Func<Name[]> result = () => qualifier;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenQualifierThenSegmentsAreReturned()
    {
        // Arrange
        ImmutableArray<Name> value = [alpha, beta];
        var qualifier = new Qualifier(value);

        // Act
        Name[] result = qualifier;

        // Assert
        await Assert.That(result).IsEqualTo([.. value]);
    }
}