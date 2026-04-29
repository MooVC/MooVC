namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Event;
        Attribute.Specifiers right = Attribute.Specifiers.Property;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }

    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Event;
        Attribute.Specifiers right = Attribute.Specifiers.Event;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}