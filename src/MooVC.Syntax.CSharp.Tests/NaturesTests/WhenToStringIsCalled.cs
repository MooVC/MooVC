namespace MooVC.Syntax.CSharp.NaturesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    [Arguments("class", nameof(Natures.Class))]
    [Arguments("struct", nameof(Natures.Struct))]
    [Arguments("unmanaged", nameof(Natures.Unmanaged))]
    [Arguments("notnull", nameof(Natures.NotNull))]
    [Arguments("", nameof(Natures.Unspecified))]
    public async Task GivenNaturesThenReturnsValue(string expected, string field)
    {
        // Arrange
        Natures subject = typeof(Natures)
            .GetField(field)!
            .GetValue(null) as Natures ?? Natures.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}