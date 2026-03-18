namespace MooVC.Syntax.Elements.QualifierTests;

public sealed class WhenImplicitOperatorFromSegmentArrayIsCalled
{
    private static readonly Name alpha = new("Alpha");
    private static readonly Name beta = new("Beta");

    [Test]
    public async Task GivenNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Name[]? values = default;

        // Act
        Func<Qualifier> result = () => values;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
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
        await Assert.That(result).IsEqualTo(values);
    }

    [Test]
    public async Task GivenSegmentsThenRoundTripsSuccessfully()
    {
        // Arrange
        Name[] values = [alpha, beta];

        // Act
        Qualifier subject = values;
        Name[] result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(values);
    }

    [Test]
    public async Task GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        Name[] values = [alpha, beta];

        // Act
        Qualifier first = values;
        Qualifier second = values;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}