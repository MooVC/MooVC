namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        object value = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute subject = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("value") });
        object value = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("value") });

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonMatchingTypeThenReturnsFalse()
    {
        // Arrange
        var value = new object();
        Attribute subject = AttributeTestsData.Create();

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        object? value = default;
        Attribute subject = AttributeTestsData.Create();

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}