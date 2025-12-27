namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

public sealed class WhenEqualsSetterIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
        Property.Setter? target = default!;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
        Property.Setter target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
        };

        var target = new Property.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
        };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        resultSubjectTarget.ShouldBeTrue();
        resultTargetSubject.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
        var target = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        resultSubjectTarget.ShouldBeFalse();
        resultTargetSubject.ShouldBeFalse();
    }
}