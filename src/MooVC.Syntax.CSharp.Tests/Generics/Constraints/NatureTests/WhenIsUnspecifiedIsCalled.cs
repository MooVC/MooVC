namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    public void GivenUnspecifiedNatureThenReturnsTrue()
    {
        // Arrange
        Nature subject = Nature.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    [Arguments(nameof(Nature.Class))]
    [Arguments(nameof(Nature.Struct))]
    [Arguments(nameof(Nature.Unmanaged))]
    [Arguments(nameof(Nature.NotNull))]
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