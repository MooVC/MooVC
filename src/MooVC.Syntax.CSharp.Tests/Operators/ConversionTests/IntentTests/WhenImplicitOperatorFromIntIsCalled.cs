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
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
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
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That((first == second)).IsTrue();
        _ = await Assert.That(first.Equals(second)).IsTrue();
    }
}