namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNatureThenReturnsValue()
    {
        // Arrange
        Nature subject = "struct";

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}