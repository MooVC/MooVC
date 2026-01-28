namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Fact]
    public void GivenUnspecifiedNatureThenReturnsTrue()
    {
        // Arrange
        Nature subject = Nature.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeTrue();
    }

    [Theory]
    [InlineData(nameof(Nature.Class))]
    [InlineData(nameof(Nature.Struct))]
    [InlineData(nameof(Nature.Unmanaged))]
    [InlineData(nameof(Nature.NotNull))]
    public void GivenSpecificNatureThenReturnsFalse(string field)
    {
        // Arrange
        Nature subject = typeof(Nature)
            .GetField(field)!
            .GetValue(null) as Nature ?? Nature.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeFalse();
    }
}