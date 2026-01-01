namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodsIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods { Get = Snippet.From("value") };
        Property.Methods? target = default!;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        Property.Methods target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        var target = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
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
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        var target = new Property.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        resultSubjectTarget.ShouldBeFalse();
        resultTargetSubject.ShouldBeFalse();
    }
}