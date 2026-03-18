namespace MooVC.Syntax.Elements.QualifierTests;

public sealed class WhenImplicitOperatorFromSegmentArrayIsCalled
{
    private static readonly Name _alpha = new("Alpha");
    private static readonly Name _beta = new("Beta");

    [Test]
    public async Task GivenNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Name[]? values = default;

        // Act
        Func<Qualifier> result = () => values;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        Name[] values = [];

        // Act
        Qualifier subject = values;

        // Assert
        _ = await Assert.That(subject).IsNotNull();
        Name[] result = subject;
        _ = await Assert.That(result).IsEquivalentTo(values);
    }

    [Test]
    public async Task GivenSegmentsThenRoundTripsSuccessfully()
    {
        // Arrange
        Name[] values = [_alpha, _beta];

        // Act
        Qualifier subject = values;
        Name[] result = subject;

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(values);
    }

    [Test]
    public async Task GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        Name[] values = [_alpha, _beta];

        // Act
        Qualifier first = values;
        Qualifier second = values;

        // Assert
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first).IsEqualTo(second);
    }
}