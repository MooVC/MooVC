namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "implicit";

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Conversion.Type subject = value;

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
        Conversion.Type first = value;
        Conversion.Type second = value;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}