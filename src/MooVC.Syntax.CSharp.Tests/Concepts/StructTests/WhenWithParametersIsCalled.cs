namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        var parameter = new Parameter { Name = new Variable("input"), Type = typeof(int) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithParameters(parameter);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Parameters).Contains(parameter);
        _ = await Assert.That(original.Parameters).IsEmpty();
    }
}