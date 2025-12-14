namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "==";

    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Comparison.Type subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
        subject.ToString().ShouldBe(value);
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Value;

        // Act
        Comparison.Type first = value;
        Comparison.Type second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}
