namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenAddThenFlagsReflectValue()
    {
        // Arrange
        Binary.Type subject = Binary.Type.Add;

        // Act
        bool isAdd = subject.IsAdd;
        bool isSubtract = subject.IsSubtract;
        string representation = subject.ToString();

        // Assert
        isAdd.ShouldBeTrue();
        isSubtract.ShouldBeFalse();
        representation.ShouldBe("+");
    }
}