namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int Value = 1;

    [Test]
    public async Task GivenValueThenEqualsInteger()
    {
        // Arrange
        int value = Value;

        // Act
        Conversion.Intent subject = value;

        // Assert
        await Assert.That((subject == value)).IsTrue();
        await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        int value = Value;

        // Act
        Conversion.Intent first = value;
        Conversion.Intent second = value;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}