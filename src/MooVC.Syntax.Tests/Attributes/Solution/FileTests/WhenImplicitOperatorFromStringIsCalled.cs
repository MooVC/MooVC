namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = FileTestsData.DefaultPath;

        // Act
        File subject = value;

        // Asserts
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }
}