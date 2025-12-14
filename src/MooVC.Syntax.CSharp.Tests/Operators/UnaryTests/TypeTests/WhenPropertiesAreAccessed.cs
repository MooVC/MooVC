namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenIncrementThenFlagsReflectValue()
    {
        // Arrange
        Unary.Type subject = Unary.Type.Increment;

        // Act
        bool isIncrement = subject.IsIncrement;
        bool isDecrement = subject.IsDecrement;
        string representation = subject.ToString();

        // Assert
        isIncrement.ShouldBeTrue();
        isDecrement.ShouldBeFalse();
        representation.ShouldBe("++");
    }
}
