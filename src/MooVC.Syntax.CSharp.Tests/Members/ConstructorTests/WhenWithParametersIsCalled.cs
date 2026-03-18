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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Extensibility).IsEqualTo(original.Extensibility);
        await Assert.That(result.Parameters).IsEqualTo([.. parameters]);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);

        await Assert.That(original.Parameters).IsEmpty();
    }
}