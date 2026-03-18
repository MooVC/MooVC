namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenReturnsSameHash()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        rightHash.ShouldBe(leftHash);
    }

    [Test]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = Struct.Kind.Ref;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        rightHash.ShouldNotBe(leftHash);
    }
}