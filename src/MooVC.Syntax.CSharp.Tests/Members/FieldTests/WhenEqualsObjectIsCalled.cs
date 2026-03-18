namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Field subject = FieldTestsData.Create();
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Field subject = FieldTestsData.Create();
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Field left = FieldTestsData.Create();
        object right = FieldTestsData.Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Field left = FieldTestsData.Create();
        object right = FieldTestsData.Create(isStatic: true);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenNonFieldThenReturnsFalse()
    {
        // Arrange
        Field subject = FieldTestsData.Create();
        object other = FieldTestsData.DefaultName;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}