namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenEqualsMethodIsCalled
{
    [Test]
    public async Task GivenDifferentBodyThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentNameThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(name: new Declaration { Name = "Alternative" });

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentParametersThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(parameters: [new Parameter { Name = "other" }]);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentResultThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        Method target = MethodTestsData.Create(result: new Result
        {
            Mode = Result.Modes.Synchronous,
            Type = new() { Name = "bool" },
        });

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentScopeThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(scope: Scopes.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Method? subject = default;
        Method target = MethodTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}