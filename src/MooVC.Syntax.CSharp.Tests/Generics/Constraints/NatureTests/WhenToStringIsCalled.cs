namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenToStringIsCalled
{
    [Theory]
    [InlineData("class", nameof(Nature.Class))]
    [InlineData("struct", nameof(Nature.Struct))]
    [InlineData("unmanaged", nameof(Nature.Unmanaged))]
    [InlineData("notnull", nameof(Nature.NotNull))]
    [InlineData("", nameof(Nature.Unspecified))]
    public void GivenNatureThenReturnsValue(string expected, string field)
    {
        // Arrange
        Nature subject = typeof(Nature)
            .GetField(field)!
            .GetValue(null) as Nature ?? Nature.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}