namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenWithArgumentsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Base original = BaseTestsData.Create();
        Token argument = (Name)"T";

        // Act
        Base result = original.WithArguments(argument);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Arguments).Contains(argument);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}