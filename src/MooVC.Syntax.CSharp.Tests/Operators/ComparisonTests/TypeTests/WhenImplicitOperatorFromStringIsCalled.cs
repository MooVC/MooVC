namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "==";

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Comparison.Type subject = value;

        // Assert
        await Assert.That((subject == value)).IsTrue();
        await Assert.That(subject.Equals(value)).IsTrue();
        await Assert.That(subject.ToString()).IsEqualTo(value);
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Value;

        // Act
        Comparison.Type first = value;
        Comparison.Type second = value;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}