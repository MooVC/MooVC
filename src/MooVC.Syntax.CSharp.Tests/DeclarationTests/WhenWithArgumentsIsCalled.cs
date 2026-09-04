namespace MooVC.Syntax.CSharp.DeclarationTests;

public sealed class WhenWithArgumentsIsCalled
{
    [Test]
    public async Task GivenArgumentsThenReturnsNewInstanceWithUpdatedArguments()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        Generic[] additional = [new() { Name = new("U") }];

        // Act
        Declaration result = original.WithArguments(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Arguments.Length).IsEqualTo(2);
        _ = await Assert.That(result.Arguments).IsEquivalentTo([.. original.Arguments, .. additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}