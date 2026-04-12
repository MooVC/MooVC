namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Qualifier.Options? left = default;
        Qualifier.Options? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Qualifier.Options left = "Block";
        Qualifier.Options right = "File";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}