namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenWithArgumentsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Implementation original = ImplementationTestsData.Create();
        Token argument = (Name)"T";

        // Act
        Implementation result = original.WithArguments(argument);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Arguments).Contains(argument);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}