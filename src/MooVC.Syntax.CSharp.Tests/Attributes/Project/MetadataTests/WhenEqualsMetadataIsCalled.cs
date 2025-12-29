namespace MooVC.Syntax.CSharp.Attributes.Project.MetadataTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsMetadataIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();
        Metadata? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();
        Metadata other = MetadataTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();
        Metadata other = MetadataTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}