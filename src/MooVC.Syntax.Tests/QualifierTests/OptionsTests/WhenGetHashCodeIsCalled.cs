namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Qualifier.Options first = "File";
        Qualifier.Options second = "File";

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}