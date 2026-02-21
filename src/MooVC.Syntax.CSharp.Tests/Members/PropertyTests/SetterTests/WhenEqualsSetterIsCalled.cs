namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsSetterIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = "value" };
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
        var subject = new Property.Setter { Behaviour = "value" };
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
            Behaviour = "value",
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
        };

        var target = new Property.Setter
        {
            Behaviour = "value",
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
        var subject = new Property.Setter { Behaviour = "value" };
        var target = new Property.Setter { Behaviour = "alternative" };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        resultSubjectTarget.ShouldBeFalse();
        resultTargetSubject.ShouldBeFalse();
    }
}