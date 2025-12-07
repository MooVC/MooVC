namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsResultIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Result? subject = default;
        Result target = ResultTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result target = ResultTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentModifiersThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create(modifier: Result.Kind.Ref);
        Result target = ResultTestsData.Create(modifier: Result.Kind.Unsafe);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentModesThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create(mode: Result.Modality.Asynchronous);
        Result target = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypesThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create(type: typeof(int));
        Result target = ResultTestsData.Create(type: typeof(string));

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}
