namespace MooVC.Syntax.CSharp.DeclarationTests;

public sealed class WhenEqualityOperatorDeclarationDeclarationIsCalled
{
    private const string AlternativeName = "Alternate";
    private static readonly string[] parameterNames = ["TFirst", "TSecond"];

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Declaration? left = default;
        Declaration? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create(AlternativeName);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentParametersThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(parameterNames: parameterNames);
        Declaration right = DeclarationTestsData.Create(parameterNames: parameterNames[0]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(parameterNames: parameterNames);
        Declaration right = DeclarationTestsData.Create(parameterNames: parameterNames);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Declaration? left = default;
        Declaration right = DeclarationTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Declaration first = DeclarationTestsData.Create();
        Declaration second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}