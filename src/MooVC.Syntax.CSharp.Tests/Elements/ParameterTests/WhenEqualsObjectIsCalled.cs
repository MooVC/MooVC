namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        object comparison = string.Empty;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create(modifier: Parameter.Mode.Out);
        object comparison = ParameterTestsData.Create(modifier: Parameter.Mode.Out);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        await Assert.That(result).IsTrue();
    }
}