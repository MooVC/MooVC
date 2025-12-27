namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsRecordIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Record subject = RecordTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Record subject = RecordTestsData.Create(methods: [new Method { Name = new Declaration { Name = "Execute" } }]);

        // Act
        bool result = subject.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Record subject = RecordTestsData.Create(events: [new Event { Name = new Identifier("Created") }]);
        Record other = RecordTestsData.Create(events: [new Event { Name = new Identifier("Created") }]);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Record subject = RecordTestsData.Create(fields: [new Field { Name = new Identifier("Value"), Type = typeof(string) }]);
        Record other = RecordTestsData.Create(fields: [new Field { Name = new Identifier("Other"), Type = typeof(string) }]);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}