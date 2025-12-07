namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenEqualsPropertyIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property? subject = PropertyTestsData.Create();
        Property? target = default!;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property target = PropertyTestsData.Create();

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
        Property subject = PropertyTestsData.Create();
        Property target = PropertyTestsData.Create(name: "Other");

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        resultSubjectTarget.ShouldBeFalse();
        resultTargetSubject.ShouldBeFalse();
    }
}
