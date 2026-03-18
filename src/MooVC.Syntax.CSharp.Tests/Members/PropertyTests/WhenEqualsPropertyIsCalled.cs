namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenEqualsPropertyIsCalled
{
    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property? subject = PropertyTestsData.Create();
        Property? target = default!;

        // Act
        bool result = subject.Equals(target);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property target = PropertyTestsData.Create();

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        await Assert.That(resultSubjectTarget).IsTrue();
        await Assert.That(resultTargetSubject).IsTrue();
    }

    [Test]
    public async Task GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property target = PropertyTestsData.Create(name: "Other");

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        await Assert.That(resultSubjectTarget).IsFalse();
        await Assert.That(resultTargetSubject).IsFalse();
    }
}