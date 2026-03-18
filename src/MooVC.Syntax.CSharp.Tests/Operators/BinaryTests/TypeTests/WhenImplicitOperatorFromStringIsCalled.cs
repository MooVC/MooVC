namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "+";

    [Test]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Binary.Type subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
        subject.ToString().ShouldBe(value);
    }

    [Test]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Value;

        // Act
        Binary.Type first = value;
        Binary.Type second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}