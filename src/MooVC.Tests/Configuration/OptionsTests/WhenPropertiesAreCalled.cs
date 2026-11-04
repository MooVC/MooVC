namespace MooVC.Configuration.OptionsTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    public async Task GivenNewOptionsThenTypeHasItsDefaultValue()
    {
        // Arrange
        var options = new TestOptions();

        // Act
        int result = options.Type;

        // Assert
        _ = await Assert.That(result).IsEqualTo(default(int));
    }

    [Test]
    public async Task GivenAnAssignedTypeThenTheValueIsRetained()
    {
        // Arrange
        const int expected = 42;
        var options = new TestOptions();

        // Act
        options.Type = expected;

        // Assert
        _ = await Assert.That(options.Type).IsEqualTo(expected);
    }

    private sealed class TestOptions
        : Options<int>
    {
    }
}