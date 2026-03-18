namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsMetadataIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();
        Metadata other = MetadataTestsData.Create(name: new Name("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}