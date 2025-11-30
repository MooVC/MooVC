namespace MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenInequalityOperatorParameterParameterIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Parameter? left = default;
        Parameter? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Parameter? left = default;
        Parameter right = ParameterTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create();
        Parameter? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(modifier: Parameter.Mode.In);
        Parameter right = ParameterTestsData.Create(modifier: Parameter.Mode.In);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentDefaultsThenReturnsTrue()
    {
        // Arrange
        Parameter left = ParameterTestsData.Create(@default: Snippet.From("alpha"));
        Parameter right = ParameterTestsData.Create(@default: Snippet.From("beta"));

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
