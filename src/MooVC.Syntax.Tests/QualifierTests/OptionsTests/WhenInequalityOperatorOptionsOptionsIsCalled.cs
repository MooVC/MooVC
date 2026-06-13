namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Qualifier.Options? left = default;
        Qualifier.Options? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Qualifier.Options left = "Block";
        Qualifier.Options right = "File";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}