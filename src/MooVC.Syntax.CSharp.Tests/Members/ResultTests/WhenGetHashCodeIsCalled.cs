namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentInstancesThenCodesMatch()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = ResultTestsData.Create();

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldBe(secondCode);
    }

    [Fact]
    public void GivenDifferentModifiersThenCodesDiffer()
    {
        // Arrange
        Result first = ResultTestsData.Create(modifier: Result.Kind.Unsafe);
        Result second = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldNotBe(secondCode);
    }

    [Fact]
    public void GivenDifferentModesThenCodesDiffer()
    {
        // Arrange
        Result first = ResultTestsData.Create(mode: Result.Modality.Asynchronous);
        Result second = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldNotBe(secondCode);
    }

    [Fact]
    public void GivenDifferentTypesThenCodesDiffer()
    {
        // Arrange
        Result first = ResultTestsData.Create(type: typeof(int));
        Result second = ResultTestsData.Create(type: typeof(string));

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldNotBe(secondCode);
    }
}
