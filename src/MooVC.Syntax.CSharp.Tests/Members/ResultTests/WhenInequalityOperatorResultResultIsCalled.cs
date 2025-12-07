namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorResultResultIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Result? left = default;
        Result? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Result? left = default;
        Result right = ResultTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentModifiersThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create(modifier: Result.Kind.Ref);
        Result right = ResultTestsData.Create(modifier: Result.Kind.RefReadOnly);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentModesThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create(mode: Result.Modality.Asynchronous);
        Result right = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentTypesThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create(type: typeof(int));
        Result right = ResultTestsData.Create(type: typeof(string));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
