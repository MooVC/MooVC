namespace MooVC.Syntax.CSharp.ParameterTests;

public sealed class WhenEqualityOperatorParameterParameterIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Parameter? left = default;
        Parameter? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentAttributesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(attributes: new Attribute { Name = new() { Name = "Left" } });
        Parameter right = ParameterTestsData.Create(attributes: new Attribute { Name = new() { Name = "Right" } });

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentModifiersThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(modifier: Parameter.Modes.Ref);
        Parameter right = ParameterTestsData.Create(modifier: Parameter.Modes.Out);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter right = ParameterTestsData.Create(name: "other");

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
        Parameter left = ParameterTestsData.Create(modifier: Parameter.Modes.In);
        Parameter right = ParameterTestsData.Create(modifier: Parameter.Modes.In);

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
        Parameter? left = default;
        Parameter right = ParameterTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Parameter first = ParameterTestsData.Create(modifier: Parameter.Modes.Ref);
        Parameter second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}