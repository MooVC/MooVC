namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Parameter { Name = new Variable("first"), Type = typeof(string) };
        var appended = new Parameter { Name = new Variable("second"), Type = typeof(int) };
        Record original = RecordTestsData.Create(parameters: [existing]);

        // Act
        Record result = original.WithParameters(appended);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.ShouldBe(new[] { existing, appended });
        result.Properties.ShouldBe(original.Properties);
    }
}