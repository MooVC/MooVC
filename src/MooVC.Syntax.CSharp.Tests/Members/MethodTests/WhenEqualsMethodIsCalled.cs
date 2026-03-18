namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Method? subject = default;
        Method target = MethodTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
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
        await Assert.That(result).IsTrue();
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
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentBodyThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
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
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentParametersThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(parameters: new[] { new Parameter { Name = "other" } });

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentResultThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        Method target = MethodTestsData.Create(result: new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = "bool" },
        });

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentScopeThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }
}