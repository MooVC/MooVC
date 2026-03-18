namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNullThenInstanceIsCreated()
    {
        // Arrange & Act & Assert
        _ = await Assert.That(() => _ = new Name(default)).ThrowsNothing();
    }

    [Test]
    public async Task GivenEmptyThenInstanceIsCreated()
    {
        // Arrange
        string value = string.Empty;

        // Act & Assert
        _ = await Assert.That(() => _ = new Name(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenWhitespaceThenInstanceIsCreated()
    {
        // Arrange
        string value = "   ";

        // Act & Assert
        _ = await Assert.That(() => _ = new Name(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenAlphaNumericThenInstanceIsCreated()
    {
        // Arrange
        string value = new Faker().Random.AlphaNumeric(32);

        // Act & Assert
        _ = await Assert.That(() => _ = new Name(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenVeryLongThenInstanceIsCreated()
    {
        // Arrange
        string value = new('x', 64_000);

        // Act & Assert
        _ = await Assert.That(() => _ = new Name(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqual()
    {
        // Arrange
        const string value = "Value";

        // Act
        var first = new Name(value);
        var second = new Name(value);

        // Assert
        _ = await Assert.That(first).IsEqualTo(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first.GetHashCode()).IsEqualTo(second.GetHashCode());
    }

    [Test]
    public async Task GivenDifferentValuesTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        const string left = "First";
        const string right = "Second";

        // Act
        var first = new Name(left);
        var second = new Name(right);

        // Assert
        _ = await Assert.That(first.Equals(second)).IsFalse();
        _ = await Assert.That(first != second).IsTrue();
    }
}