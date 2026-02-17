namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSegmentArrayIsCalled
{
    private static readonly Name alpha = new("Alpha");
    private static readonly Name beta = new("Beta");

    [Fact]
    public void GivenNullQualifierThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? qualifier = default;

        // Act
        Func<Name[]> result = () => qualifier;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenQualifierThenSegmentsAreReturned()
    {
        // Arrange
        ImmutableArray<Name> value = [alpha, beta];
        var qualifier = new Qualifier(value);

        // Act
        Name[] result = qualifier;

        // Assert
        result.ShouldBe([.. value]);
    }
}