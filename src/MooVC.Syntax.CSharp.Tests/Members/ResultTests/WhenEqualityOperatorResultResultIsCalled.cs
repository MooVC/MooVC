namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorResultResultIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Result? left = default;
        Result? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Result? left = default;
        Result right = ResultTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentModifiersThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create(modifier: Result.Kind.Ref);
        Result right = ResultTestsData.Create(modifier: Result.Kind.RefReadOnly);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentModesThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create(mode: Result.Modality.Asynchronous);
        Result right = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypesThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create(type: typeof(int));
        Result right = ResultTestsData.Create(type: typeof(string));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
