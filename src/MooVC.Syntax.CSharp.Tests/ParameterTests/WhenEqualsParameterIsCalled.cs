namespace MooVC.Syntax.CSharp.ParameterTests;

public sealed class WhenEqualsParameterIsCalled
{
    private const string AlternativeName = "other";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Parameter? left = default;
        Parameter? right = default;

        // Act
        bool result = left?.Equals(right) ?? (right is null);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentAttributesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(attributes: new Attribute { Name = new Symbol { Name = "First" } });
        Parameter right = ParameterTestsData.Create(attributes: new Attribute { Name = new Symbol { Name = "Second" } });

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter right = ParameterTestsData.Create(name: AlternativeName);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(@default: Snippet.From("42"));
        Parameter right = ParameterTestsData.Create(@default: Snippet.From("42"));

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Parameter? left = default;
        Parameter right = ParameterTestsData.Create();

        // Act
        bool result = left?.Equals(right) ?? false;

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
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Parameter first = ParameterTestsData.Create(modifier: Parameter.Mode.RefReadonly);
        Parameter second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}