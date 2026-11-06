namespace MooVC.Serialization.Configuration.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    [Arguments("Json")]
    [Arguments("Newtonsoft.Json")]
    [Arguments("MessagePack")]
    [Arguments("Apex")]
    public async Task GivenANameWhenRoundTrippedThenTheOriginalValueIsRetained(string expected)
    {
        // Arrange & Act
        Type type = expected;
        string actual = type;

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
        _ = await Assert.That(type.ToString()).IsEqualTo(expected);
    }
}