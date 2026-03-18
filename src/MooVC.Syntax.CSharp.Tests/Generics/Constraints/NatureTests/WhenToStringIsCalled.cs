namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    [Arguments("class", nameof(Nature.Class))]
    [Arguments("struct", nameof(Nature.Struct))]
    [Arguments("unmanaged", nameof(Nature.Unmanaged))]
    [Arguments("notnull", nameof(Nature.NotNull))]
    [Arguments("", nameof(Nature.Unspecified))]
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