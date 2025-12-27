namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorRecordRecordIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Record? left = default;
        Record? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Record? left = default;
        Record right = RecordTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Record left = RecordTestsData.Create();
        Record? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Record first = RecordTestsData.Create();
        Record second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create(parameters: [new Parameter { Name = new Identifier("input"), Type = typeof(string) }]);
        Record right = RecordTestsData.Create(parameters: [new Parameter { Name = new Identifier("input"), Type = typeof(string) }]);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Record left = RecordTestsData.Create();
        Record right = RecordTestsData.Create(name: new Declaration { Name = new Identifier("Other") });

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentExtensibilitiesThenReturnsTrue()
    {
        // Arrange
        Record left = RecordTestsData.Create(extensibility: Extensibility.Abstract);
        Record right = RecordTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}