namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Method? subject = default;
        Method target = MethodTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentBodyThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentNameThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(name: new Declaration { Name = "Alternative" });

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentParametersThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(parameters: new[] { new Parameter { Name = "other" } });

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentResultThenReturnsFalse()
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
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentScopeThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}