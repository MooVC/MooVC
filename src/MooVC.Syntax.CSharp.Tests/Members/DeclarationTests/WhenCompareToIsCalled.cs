namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenCompareToIsCalled
{
    private const string Alpha = "Alpha";
    private const string Beta = "Beta";

    [Test]
    public async Task GivenNullOtherThenReturnsOne()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        Declaration? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(1);
    }

    [Test]
    public async Task GivenLowerNameThenReturnsNegative()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create(Alpha);
        Declaration other = DeclarationTestsData.Create(Beta);

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsLessThan(0);
    }

    [Test]
    public async Task GivenEqualNamesThenReturnsZero()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create(Alpha);
        Declaration other = DeclarationTestsData.Create(Alpha);

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(0);
    }
}