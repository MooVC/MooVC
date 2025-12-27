namespace MooVC.Syntax.CSharp.Members.IdentifierTests.CasingTests;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int PascalValue = 0;
    private const int CamelValue = 1;

    [Fact]
    public void GivenValueThenEqualsInt()
    {
        // Arrange
        int value = CamelValue;

        // Act
        Identifier.Casing subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        int value = PascalValue;

        // Act
        Identifier.Casing subject = value;
        int result = subject;

        // Assert
        result.ShouldBe(value);
    }
}
