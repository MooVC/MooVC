namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenComparisonOperatorsDeclarationDeclarationIsCalled
{
    private const string Alpha = "Alpha";
    private const string Beta = "Beta";

    [Test]
    public void GivenLeftNullThenLessThanReturnsTrue()
    {
        // Arrange
        Declaration? left = default;
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left < right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenGreaterNameThenGreaterThanReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(Beta);
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left > right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualNamesThenLessThanOrEqualReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(Alpha);
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left <= right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualNamesThenGreaterThanOrEqualReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(Alpha);
        Declaration right = DeclarationTestsData.Create(Alpha);

        // Act
        bool result = left >= right;

        // Assert
        result.ShouldBeTrue();
    }
}