namespace MooVC.Syntax.CSharp.Members.ResultTests;

using System;
using System.Threading.Tasks;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenAsIsCalled
{
    [Fact]
    public void GivenNullWrapperThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Result subject = ResultTestsData.Create();

        // Act
        Action action = () => subject.As(wrapper: null!);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenWrapperThenTypeIsUpdated()
    {
        // Arrange
        Result subject = ResultTestsData.Create(type: typeof(int));

        // Act
        Result result = subject.As(typeof(ValueTuple));

        // Assert
        result.ShouldNotBeSameAs(subject);
        result.Mode.ShouldBe(subject.Mode);
        result.Modifier.ShouldBe(subject.Modifier);
        result.Type.ShouldBe(subject.Type.WithQualifier(typeof(ValueTuple)).WithArguments(subject.Type));
    }

    [Fact]
    public void GivenTaskThenTypeIsWrapped()
    {
        // Arrange
        Result subject = ResultTestsData.Create(type: typeof(int));

        // Act
        Result result = subject.AsTask();

        // Assert
        result.ShouldBe(subject.As(typeof(Task)));
    }

    [Fact]
    public void GivenValueTaskThenTypeIsWrapped()
    {
        // Arrange
        Result subject = ResultTestsData.Create(type: typeof(int));

        // Act
        Result result = subject.AsValueTask();

        // Assert
        result.ShouldBe(subject.As(typeof(ValueTask)));
    }
}
