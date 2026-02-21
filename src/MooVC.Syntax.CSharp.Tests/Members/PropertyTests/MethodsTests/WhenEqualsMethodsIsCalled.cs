namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodsIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods { Get = "value" };
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
            Get = "value",
            Set = new Property.Setter { Behaviour = "value = input" },
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
            Get = "value",
            Set = new Property.Setter { Behaviour = "value = input" },
        };

        var target = new Property.Methods
        {
            Get = "value",
            Set = new Property.Setter { Behaviour = "value = input" },
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
            Get = "value",
        };

        var target = new Property.Methods
        {
            Get = "alternative",
        };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        resultSubjectTarget.ShouldBeFalse();
        resultTargetSubject.ShouldBeFalse();
    }
}