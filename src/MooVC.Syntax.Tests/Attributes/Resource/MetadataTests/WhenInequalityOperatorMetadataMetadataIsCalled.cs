namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMetadataMetadataIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Metadata? left = default;
        Metadata? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Metadata? left = default;
        Metadata right = MetadataTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Metadata left = MetadataTestsData.Create();
        Metadata right = MetadataTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Metadata left = MetadataTestsData.Create();
        Metadata right = MetadataTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}