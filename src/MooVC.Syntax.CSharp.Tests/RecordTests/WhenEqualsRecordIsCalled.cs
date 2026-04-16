namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenEqualsRecordIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Record subject = RecordTestsData.Create(fields: [new Field { Name = "Value", Type = typeof(string) }]);
        Record other = RecordTestsData.Create(fields: [new Field { Name = "Other", Type = typeof(string) }]);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Record subject = RecordTestsData.Create(events: [new Event { Name = "Created" }]);
        Record other = RecordTestsData.Create(events: [new Event { Name = "Created" }]);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Record subject = RecordTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Record subject = RecordTestsData.Create(methods: [new Method { Name = new() { Name = "Execute" } }]);

        // Act
        bool result = subject.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}