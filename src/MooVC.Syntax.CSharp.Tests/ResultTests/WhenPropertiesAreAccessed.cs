namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenTaskResultThenFlagsReflectValue()
    {
        // Arrange
        Result subject = Result.Task;

        // Act
        bool isTask = subject.IsTask;
        bool isUndefined = subject.IsUndefined;
        bool isVoid = subject.IsVoid;

        // Assert
        _ = await Assert.That(isTask).IsTrue();
        _ = await Assert.That(isUndefined).IsFalse();
        _ = await Assert.That(isVoid).IsFalse();
    }

    [Test]
    public async Task GivenUndefinedResultThenFlagsReflectValue()
    {
        // Arrange
        Result subject = Result.Undefined;

        // Act
        bool isTask = subject.IsTask;
        bool isUndefined = subject.IsUndefined;
        bool isVoid = subject.IsVoid;

        // Assert
        _ = await Assert.That(isTask).IsFalse();
        _ = await Assert.That(isUndefined).IsTrue();
        _ = await Assert.That(isVoid).IsFalse();
    }

    [Test]
    public async Task GivenVoidResultThenFlagsReflectValue()
    {
        // Arrange
        Result subject = Result.Void;

        // Act
        bool isTask = subject.IsTask;
        bool isUndefined = subject.IsUndefined;
        bool isVoid = subject.IsVoid;

        // Assert
        _ = await Assert.That(isTask).IsFalse();
        _ = await Assert.That(isUndefined).IsFalse();
        _ = await Assert.That(isVoid).IsTrue();
    }
}