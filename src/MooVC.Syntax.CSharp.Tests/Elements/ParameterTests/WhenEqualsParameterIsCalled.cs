namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using Attribute = MooVC.Syntax.CSharp.Members.Attribute;

public sealed class WhenEqualsParameterIsCalled
{
    private const string AlternativeName = "other";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Parameter? left = default;
        Parameter? right = default;

        // Act
        bool result = left?.Equals(right) ?? (right is null);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Parameter? left = default;
        Parameter right = ParameterTestsData.Create();

        // Act
        bool result = left?.Equals(right) ?? false;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Parameter first = ParameterTestsData.Create(modifier: Parameter.Mode.RefReadonly);
        Parameter second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(@default: Snippet.From("42"));
        Parameter right = ParameterTestsData.Create(@default: Snippet.From("42"));

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter right = ParameterTestsData.Create(name: AlternativeName);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentAttributesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(attributes: new Attribute { Name = new Symbol { Name = new Identifier("First") } });
        Parameter right = ParameterTestsData.Create(attributes: new Attribute { Name = new Symbol { Name = new Identifier("Second") } });

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}