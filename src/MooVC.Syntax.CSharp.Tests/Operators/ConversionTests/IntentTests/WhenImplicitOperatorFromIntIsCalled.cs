namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int Value = 1;

    [Test]
    public void GivenValueThenEqualsInteger()
    {
        // Arrange
        int value = Value;

        // Act
        Conversion.Intent subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        int value = Value;

        // Act
        Conversion.Intent first = value;
        Conversion.Intent second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}