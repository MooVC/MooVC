namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "--";

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Value;

        // Act
        Unary.Types first = value;
        Unary.Types second = value;

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
        Unary.Types subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
        _ = await Assert.That(subject.ToString()).IsEqualTo(value);
    }
}