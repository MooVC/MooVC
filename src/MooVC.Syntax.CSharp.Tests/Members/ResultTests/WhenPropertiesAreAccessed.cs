namespace MooVC.Syntax.CSharp.Members.ResultTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenTaskResultThenFlagsReflectValue()
    {
        // Arrange
        Result subject = Result.Task;

        // Act
        bool isTask = subject.IsTask;
        bool isUndefined = subject.IsUndefined;
        bool isVoid = subject.IsVoid;

        // Assert
        isTask.ShouldBeTrue();
        isUndefined.ShouldBeFalse();
        isVoid.ShouldBeFalse();
    }

    [Fact]
    public void GivenUndefinedResultThenFlagsReflectValue()
    {
        // Arrange
        Result subject = Result.Undefined;

        // Act
        bool isTask = subject.IsTask;
        bool isUndefined = subject.IsUndefined;
        bool isVoid = subject.IsVoid;

        // Assert
        isTask.ShouldBeFalse();
        isUndefined.ShouldBeTrue();
        isVoid.ShouldBeFalse();
    }

    [Fact]
    public void GivenVoidResultThenFlagsReflectValue()
    {
        // Arrange
        Result subject = Result.Void;

        // Act
        bool isTask = subject.IsTask;
        bool isUndefined = subject.IsUndefined;
        bool isVoid = subject.IsVoid;

        // Assert
        isTask.ShouldBeFalse();
        isUndefined.ShouldBeFalse();
        isVoid.ShouldBeTrue();
    }
}