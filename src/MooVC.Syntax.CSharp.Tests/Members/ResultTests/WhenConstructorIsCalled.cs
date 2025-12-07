namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Result();

        // Assert
        subject.Modifier.ShouldBe(Result.Kind.None);
        subject.Mode.ShouldBe(Result.Modality.Asynchronous);
        subject.Type.ShouldBe(Symbol.Unspecified);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Result.Kind modifier = Result.Kind.Ref;
        Result.Modality mode = Result.Modality.Synchronous;
        Symbol type = typeof(int);

        // Act
        var subject = new Result
        {
            Modifier = modifier,
            Mode = mode,
            Type = type,
        };

        // Assert
        subject.Modifier.ShouldBe(modifier);
        subject.Mode.ShouldBe(mode);
        subject.Type.ShouldBe(type);
    }
}
