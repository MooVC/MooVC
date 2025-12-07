namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        object? comparison = default;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        object comparison = string.Empty;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        object comparison = subject;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualResultThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        object comparison = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenResultWithDifferentModifierThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create(modifier: Result.Kind.Unsafe);
        object comparison = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenResultWithDifferentModeThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create(mode: Result.Modality.Asynchronous);
        object comparison = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenResultWithDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create(type: typeof(int));
        object comparison = ResultTestsData.Create(type: typeof(string));

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }
}
