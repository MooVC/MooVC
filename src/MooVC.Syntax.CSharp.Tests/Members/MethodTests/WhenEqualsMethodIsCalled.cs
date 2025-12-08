namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenEqualsMethodIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
    public void GivenDifferentNameThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        Method target = MethodTestsData.Create(name: new Declaration { Name = new Identifier("Alternative") });

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
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

    [Fact]
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

    [Fact]
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
