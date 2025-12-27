namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenCompareToIsCalled
{
    private const string Alpha = "Alpha";
    private const string Beta = "Beta";

    [Fact]
    public void GivenNullOtherThenReturnsOne()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        Declaration? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        result.ShouldBe(1);
    }

    [Fact]
    public void GivenLowerNameThenReturnsNegative()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create(Alpha);
        Declaration other = DeclarationTestsData.Create(Beta);

        // Act
        int result = subject.CompareTo(other);

        // Assert
        result.ShouldBeLessThan(0);
    }

    [Fact]
    public void GivenEqualNamesThenReturnsZero()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create(Alpha);
        Declaration other = DeclarationTestsData.Create(Alpha);

        // Act
        int result = subject.CompareTo(other);

        // Assert
        result.ShouldBe(0);
    }
}
