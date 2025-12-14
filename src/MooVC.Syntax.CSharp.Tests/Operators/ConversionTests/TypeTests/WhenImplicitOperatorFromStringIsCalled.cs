namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "implicit";

    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Conversion.Type subject = value;

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
        Conversion.Type first = value;
        Conversion.Type second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}