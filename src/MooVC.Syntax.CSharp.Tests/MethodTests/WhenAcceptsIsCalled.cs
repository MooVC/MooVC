namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenAcceptsIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsNewInstanceWithUpdatedParameters()
    {
        // Arrange
        Method original = MethodTestsData.Create();

        Parameter[] additional =
        [
            new Parameter
            {
                Name = new("other"),
                Type = new() { Name = MethodTestsData.DefaultParameterType },
            },
        ];

        // Act
        Method result = original.Accepts(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Parameters.Length).IsEqualTo(original.Parameters.Length + additional.Length);
        _ = await Assert.That(result.Parameters).IsEquivalentTo([.. original.Parameters, .. additional]);
        _ = await Assert.That(result.Result).IsEqualTo(original.Result);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}