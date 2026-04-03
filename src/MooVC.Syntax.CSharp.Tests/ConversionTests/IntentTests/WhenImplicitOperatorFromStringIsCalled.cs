namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "From";

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Value;

        // Act
        Conversion.Intent first = value;
        Conversion.Intent second = value;

        // Assert
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first).IsEqualTo(second);
    }

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Conversion.Intent subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }
}