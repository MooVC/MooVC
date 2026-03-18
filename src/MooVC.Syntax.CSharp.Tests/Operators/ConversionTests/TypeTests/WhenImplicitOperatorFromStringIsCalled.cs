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
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
        _ = await Assert.That(subject.ToString()).IsEqualTo(value);
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
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That((first == second)).IsTrue();
        _ = await Assert.That(first.Equals(second)).IsTrue();
    }
}