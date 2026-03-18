namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Parameter { Name = new Variable("first"), Type = typeof(string) };
        var appended = new Parameter { Name = new Variable("second"), Type = typeof(int) };
        Record original = RecordTestsData.Create(parameters: [existing]);

        // Act
        Record result = original.WithParameters(appended);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Parameters).IsEqualTo(new[] { existing, appended });
        _ = await Assert.That(result.Properties).IsEqualTo(original.Properties);
    }
}