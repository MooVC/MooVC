namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenComparisonOperatorsDeclarationDeclarationIsCalled
{
    private const string Alpha = "Alpha";
    private const string Beta = "Beta";

    [Test]
    public async Task GivenLeftNullThenLessThanReturnsTrue()
    {
        // Arrange
        Declaration? left = default;
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left < right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenGreaterNameThenGreaterThanReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(Beta);
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left > right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualNamesThenLessThanOrEqualReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(Alpha);
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left <= right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualNamesThenGreaterThanOrEqualReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(Alpha);
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left >= right;

        // Assert
        await Assert.That(result).IsTrue();
    }
}