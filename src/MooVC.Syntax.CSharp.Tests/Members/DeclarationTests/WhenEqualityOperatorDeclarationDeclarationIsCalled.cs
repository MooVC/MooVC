namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenEqualityOperatorDeclarationDeclarationIsCalled
{
    private const string AlternativeName = "Alternate";
    private static readonly string[] parameterNames = ["TFirst", "TSecond"];

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Declaration? left = default;
        Declaration? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Declaration? left = default;
        Declaration right = DeclarationTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Declaration first = DeclarationTestsData.Create();
        Declaration second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(parameterNames: parameterNames);
        Declaration right = DeclarationTestsData.Create(parameterNames: parameterNames);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create(AlternativeName);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentParametersThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(parameterNames: parameterNames);
        Declaration right = DeclarationTestsData.Create(parameterNames: parameterNames[0]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}