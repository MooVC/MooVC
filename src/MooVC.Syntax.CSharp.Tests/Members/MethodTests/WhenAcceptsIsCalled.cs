namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

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
                Name = new Variable("other"),
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
        ];

        // Act
        Method result = original.Accepts(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Parameters.Length).IsEqualTo(original.Parameters.Length + additional.Length);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters.Concat(additional));
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}