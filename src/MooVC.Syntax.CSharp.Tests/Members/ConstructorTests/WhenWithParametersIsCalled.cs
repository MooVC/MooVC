namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsNewInstanceWithUpdatedParameters()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        Parameter[] parameters =
        [
            ParameterTestsData.Create(name: "other"),
        ];

        // Act
        Constructor result = original.WithParameters([.. parameters]);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Extensibility).IsEqualTo(original.Extensibility);
        _ = await Assert.That(result.Parameters).IsEquivalentTo([.. parameters]);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);

        _ = await Assert.That(original.Parameters).IsEmpty();
    }
}