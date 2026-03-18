namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Event;
        Attribute.Specifier right = Attribute.Specifier.Event;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Event;
        Attribute.Specifier right = Attribute.Specifier.Property;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}